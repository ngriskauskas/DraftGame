using System.Threading.Tasks;
using Draft.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draft.Web.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : Controller
    {
        private readonly LeagueService _leagueService;

        public LeagueController(LeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Start()
        {
            _leagueService.StartLeague();
            return Ok();
        }
    }
}