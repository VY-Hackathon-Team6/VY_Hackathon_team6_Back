using Infrastucture.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Persistence
{
    public class UserDBContext : IdentityDbContext<UserDataModel>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
    }
}