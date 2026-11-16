using Microsoft.AspNetCore.Identity;
using scrap_depot.Models;

namespace scrap_depot.Data;

public static class RoleSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<EmployeeUser>>();
        var config = services.GetRequiredService<IConfiguration>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        var email = config["Admin:Email"];
        if (string.IsNullOrEmpty(email))
        {
            return;
        }

        var member = await userManager.FindByEmailAsync(email);
        if (member != null && !await userManager.IsInRoleAsync(member, "Admin"))
        {
            await userManager.AddToRoleAsync(member, "Admin");
        }
    }
}