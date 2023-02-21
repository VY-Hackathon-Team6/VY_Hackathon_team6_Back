using Microsoft.AspNetCore.Identity;

namespace Infrastucture.DataModels
{
    public class UserDataModel: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}