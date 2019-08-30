using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Events;
using Draft.Core.Interfaces;
using Draft.Inf.Identity;
using Draft.Web.Utils;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Draft.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamClaimController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository _repository;
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly IMapper _mapper;
        private readonly ITimerService _timerService;

        public TeamClaimController(UserManager<AppUser> userManager,
                                IRepository repository,
                                IDomainEventDispatcher dispatcher,
                                IMapper mapper,
                                ITimerService timerService)
        {
            _userManager = userManager;
            _repository = repository;
            _dispatcher = dispatcher;
            _mapper = mapper;
            _timerService = timerService;
        }


        [HttpPost("[Action]")]
        [Authorize]
        public async Task<IActionResult> ClaimTeam([FromBody] int teamId)
        {
            if (_userManager.Users.Any(u => u.TeamId == teamId))
                return BadRequest("Team is already claimed");

            var user = await _userManager.GetAppUser(HttpContext.User);

            if (await _userManager.IsInRoleAsync(user, "TeamManager"))
                _dispatcher.Dispatch(new TeamUnClaimedEvent(user.TeamId));
            else
                await _userManager.AddToRoleAsync(user, "TeamManager");

            user.TeamId = teamId;
            await _userManager.UpdateAsync(user);
            _dispatcher.Dispatch(new TeamClaimedEvent(teamId));

            _timerService.AddTeamManager(user.Id);
            return Ok();
        }

        [HttpPost("[Action]")]
        [Authorize(Roles = "TeamManager")]
        public async Task<IActionResult> UnClaimTeam()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            user.TeamId = 0;
            await _userManager.UpdateAsync(user);
            _dispatcher.Dispatch(new TeamUnClaimedEvent(user.TeamId));
            await _userManager.RemoveFromRoleAsync(user, "TeamManager");
            _timerService.RemoveTeamManager(user.Id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _repository.ListAsync<Team>();
            var teamManagers = await _userManager.GetUsersInRoleAsync("TeamManager");
            var models = _mapper.Map<List<Team>, TeamClaimViewModel[]>(teams);

            foreach (var model in models)
                if (teamManagers.Any(tm => tm.TeamId == model.Id))
                    model.Claimed = true;

            return Ok(models);
        }
    }
}