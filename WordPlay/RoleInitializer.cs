using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordPlay.Models;
using Microsoft.AspNetCore.Identity;

namespace TimeToplay
{
    public class RoleInitializer
    {
        public static async Task RoleInitializerAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "v1@gmail.com";
            string adminName = "himasyury";
            string password = "Qwerty1234";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await roleManager.FindByNameAsync("moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("moderator"));
            }
            if ( await userManager.FindByNameAsync(adminName) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminName };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
