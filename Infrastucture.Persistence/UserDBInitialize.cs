using Infrastucture.DataModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistence
{
    public class UserDBInitialize
    {
        public static async Task SeedRoles(IApplicationBuilder applicationBuilder)
        {
            var scopeFactory = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Viewer" });
            }
        }

        public static async Task SeedUsers(IApplicationBuilder applicationBuilder)
        {
            var scopeFactory = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserDataModel>>();

            if (!userManager.Users.Any())
            {
                var davidUser = new UserDataModel { Email = "david.jimenez@col.vueling.com", UserName = "david.jimenez@col.vueling.com", Name = "David", Surname = "Jimenez" };
                var lauraUser = new UserDataModel { Email = "laura.guerra@col.vueling.com", UserName = "laura.guerra@col.vueling.com", Name = "Laura", Surname = "Guerra" }; 
                var davidResult = await userManager.CreateAsync(davidUser, "Hola1234!");
                var lauraResult = await userManager.CreateAsync(lauraUser, "Hola1234!");

                if (davidResult.Succeeded)
                    await userManager.AddToRoleAsync(davidUser, "Admin");

                if (lauraResult.Succeeded)
                    await userManager.AddToRoleAsync(lauraUser, "Viewer");


            }

        }
    }
}
