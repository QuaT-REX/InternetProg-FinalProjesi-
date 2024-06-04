using Microsoft.AspNetCore.Identity;

namespace AracKiralamaPortali.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
