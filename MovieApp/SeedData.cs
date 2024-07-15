using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;


namespace MovieApp
{
   public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = { "Admin","Writer", "Reader", "User" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var poweruser = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
            };

            string userPWD = "Admin@123";
            var _user = await userManager.FindByEmailAsync("admin@admin.com");

            if (_user == null)
            {
                var createPowerUser = await userManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(poweruser, "Admin");
                }
                else
                {
                    // Log errors if user creation fails
                    foreach (var error in createPowerUser.Errors)
                    {
                        Console.WriteLine($"Error creating user: {error.Description}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Admin user already exists.");
            }
        }
    }
}