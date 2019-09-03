using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.Services;
using Draft.Core.Specifications;
using Draft.Inf.Identity;
using Draft.Web.Utils;
using Draft.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Draft.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaiverController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly WaiverService _waiverService;
        private readonly TeamService _teamService;
        private readonly UserManager<AppUser> _userManager;

        public WaiverController(IRepository repository,
                                IMapper mapper,
                                WaiverService waiverService,
                                TeamService teamService,
                                UserManager<AppUser> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _waiverService = waiverService;
            _teamService = teamService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetWaiver()
        {
            var season = await _repository.GetAsync(new CurrentSeasonWithWaiver());
            var model = _mapper.Map<List<Player>, WaiverPlayerViewModel[]>(season.Waiver.Players);
            return Ok(model);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddToWaiver([FromBody] List<int> playerIds)
        {
            var user = await _userManager.GetAppUser(HttpContext.User);

            await _teamService.RemovePlayersAsync(user.TeamId, playerIds);
            await _waiverService.AddPlayersAsync(playerIds);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveFromWaiver([FromBody] List<int> playerIds)
        {
            var user = await _userManager.GetAppUser(HttpContext.User);

            var result = await _teamService.AddPlayersAsync(user.TeamId, playerIds);
            if (!result) return BadRequest("Roster over player Cap");
            await _waiverService.RemovePlayersAsync(playerIds);
            return Ok();
        }
    }
}