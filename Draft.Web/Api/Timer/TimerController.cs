using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Draft.Core.Interfaces;
using Draft.Inf.Identity;
using Draft.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Draft.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerController : Controller
    {
        private readonly IHubContext<TimerHub, ITimerHub> _timerHub;
        private readonly ITimerService _timerService;
        private readonly UserManager<AppUser> _userManager;

        public TimerController(IHubContext<TimerHub, ITimerHub> timerHub,
                                ITimerService timerService,
                                UserManager<AppUser> userManager)
        {
            _timerHub = timerHub;
            _timerService = timerService;
            _userManager = userManager;
        }


        [HttpPost("[Action]")]
        [Authorize(Roles = "TeamManager")]
        public async Task<IActionResult> TeamReady()
        {
            var user = await _userManager.GetAppUser(HttpContext.User);
            _timerService.SetManagerReady(user.Id, true);
            return Ok();
        }

        [HttpPost("[Action]")]
        [Authorize(Roles = "TeamManager")]
        public async Task<IActionResult> TeamUnReady()
        {
            var user = await _userManager.GetAppUser(HttpContext.User);
            _timerService.SetManagerReady(user.Id, false);
            return Ok();
        }
    }
}