using Microsoft.AspNetCore.Identity;

namespace Draft.Inf.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() { }
        public AppRole(string name)
        {
            Name = name;
        }
    }
}