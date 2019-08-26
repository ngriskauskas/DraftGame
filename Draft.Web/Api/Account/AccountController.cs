using System.Linq;
using System.Threading.Tasks;
using Draft.Core.Entities;
using Draft.Core.Interfaces;
using Draft.Inf.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Draft.Web.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace Draft.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository _repository;

        public AccountController(UserManager<AppUser> userManager, IRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
                return BadRequest("A User with that email already exists");

            user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true,
                LockoutEnabled = false
            };

            var registerResult = await _userManager.CreateAsync(user, model.Password);

            await _userManager.AddToRoleAsync(user, "Spectator");

            return Ok();
        }
    }
}