using Microsoft.AspNetCore.Identity;
namespace Draft.Inf.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public int TeamId { get; set; }
        public string RefreshToken { get; set; }
    }
}