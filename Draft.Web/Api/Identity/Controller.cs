using System.Linq;
using System.Threading.Tasks;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Inf.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Draft.Web.Api
{
    public class RegisterController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository _repository;

        public RegisterController(UserManager<AppUser> userManager, IRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = _repository.GetById<Team>(model.TeamId);
            if (team == null)
                return BadRequest("That team does not exist");

            var user = _userManager.Users.SingleOrDefault(u => u.TeamId == model.TeamId);

            if (user != null)
                return BadRequest("That team is already selected");

            user = new AppUser { UserName = model.UserName, TeamId = model.TeamId };

            var registerResult = await _userManager.CreateAsync(user);

            if (!registerResult.Succeeded)
                return BadRequest(registerResult.Errors);

            return Ok(new TokenViewModel
            {
                UserName = user.UserName,
                TeamId = user.TeamId
            });
        }


    }
}