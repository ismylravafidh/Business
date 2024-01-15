using Microsoft.AspNetCore.Identity;

namespace Business.Common
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
