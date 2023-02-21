

using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}
