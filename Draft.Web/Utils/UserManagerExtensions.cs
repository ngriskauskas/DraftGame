using System.Security.Claims;
using System.Threading.Tasks;
using Draft.Inf.Identity;
using Microsoft.AspNetCore.Identity;

namespace Draft.Web.Utils
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> GetAppUser(this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            return await userManager.FindByNameAsync(userManager.GetUserName(user));
        }
    }
}