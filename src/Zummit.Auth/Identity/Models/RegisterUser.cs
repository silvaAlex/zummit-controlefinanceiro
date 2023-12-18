using System.ComponentModel.DataAnnotations;

namespace Zummit.Auth.Identity.Models
{
    public class RegisterUser
    {
        [Required]
	    public string? Nome { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; }

        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
