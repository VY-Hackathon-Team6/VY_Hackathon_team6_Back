using Application.Services.Profiles;
using Infrastucture.DataModels;
using Infrastucture.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Services.Config
{
    public static class IoC
    {
        public static IServiceCollection ConfigServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddTransient<UserManager<UserDataModel>>();

            var connectionString = Environment.GetEnvironmentVariable("Connection string");
            services.AddDbContext<UserDBContext>(options => options.UseInMemoryDatabase("usersDB"))
                .AddIdentityCore<UserDataModel>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UserDBContext>();

            return services;
        }
    }
}
