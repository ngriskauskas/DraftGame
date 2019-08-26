using System.Linq;
using Draft.Inf.Data;
using Microsoft.AspNetCore.Identity;

namespace Draft.Inf.Identity
{
    public static class IdentitySeeder
    {
        public static UserManager<AppUser> UserManager { get; set; }
        public static RoleManager<AppRole> RoleManager { get; set; }
        public static void SeedIdentity(this AppDbContext db)
        {
            AddRoles(db);
            AddUsers(db);
        }
        private static void AddRoles(AppDbContext db)
        {
            if (RoleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult() == false)
                RoleManager.CreateAsync(new AppRole("Admin")).GetAwaiter().GetResult();

            if (RoleManager.RoleExistsAsync("TeamManager").GetAwaiter().GetResult() == false)
                RoleManager.CreateAsync(new AppRole("TeamManager")).GetAwaiter().GetResult();

            if (RoleManager.RoleExistsAsync("Spectator").GetAwaiter().GetResult() == false)
                RoleManager.CreateAsync(new AppRole("Spectator")).GetAwaiter().GetResult();
        }
        private static void AddUsers(AppDbContext db)
        {
            if (UserManager.FindByEmailAsync("ngriskauskas@gmail.com").GetAwaiter().GetResult() == null)
            {
                AppUser admin = new AppUser
                {
                    UserName = "ngriskauskas",
                    Email = "ngriskauskas@gmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };
                UserManager.CreateAsync(admin, "Hcpslink1!").GetAwaiter().GetResult();
                UserManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
            }
        }
    }
}