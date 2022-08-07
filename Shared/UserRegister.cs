using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleThings.Shared
{
    public class UserRegister
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare("Password", ErrorMessage = "The password does not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
