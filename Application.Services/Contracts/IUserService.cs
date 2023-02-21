using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<string> Login(User user);
        Task<IEnumerable<User>> GetUsers();
    }
}
