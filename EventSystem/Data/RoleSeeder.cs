using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public static class RoleSeeder
{
    private static readonly string[] Roles = new string[] { "User", "Manager" };

    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var systemAdmin = await userManager.FindByEmailAsync("manager@gmail.com");
        if (systemAdmin == null)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "manager@gmail.com",
                Email = "manager@gmail.com",
                EmailConfirmed = true,
            };

            var result = await userManager.CreateAsync(defaultUser, "Manager@123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(defaultUser, "Manager");
            }
        }
    }
}
