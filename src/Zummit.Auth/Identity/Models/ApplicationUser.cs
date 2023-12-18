using Microsoft.AspNetCore.Identity;

namespace Zummit.Auth.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Nome { get; set; }
    }
}
