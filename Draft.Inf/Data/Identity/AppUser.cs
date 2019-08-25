using Microsoft.AspNetCore.Identity;
namespace Draft.Inf.Identity
{
    public class AppUser : IdentityUser
    {
        public int TeamId { get; set; }

    }
}