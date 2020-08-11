using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("burhan");
            if (adminUser==null)
            {
                AppUser user = new AppUser
                {
                    Name = "Burhan",
                    Surname = "Dayıoğlu",
                    UserName = "burhan",
                    Email = "burhan_gf5226@hotmail.com"
                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
