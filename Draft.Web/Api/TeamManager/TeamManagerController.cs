using System.Threading.Tasks;
using AutoMapper;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Core.Specifications;
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
    public class TeamManagerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TeamManagerController(UserManager<AppUser> userManager, IRepository repository, IMapper mapper)
        {
            _userManager = userManager;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "TeamManager")]
        public async Task<IActionResult> GetTeam()
        {
            var user = await _userManager.GetAppUser(HttpContext.User);
            var team = await _repository.GetAsync(new FullTeam(user.TeamId));
            var model = _mapper.Map<Team, TeamViewModel>(team);
            return Ok(model);
        }
    }
}