using System;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Poolside.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        public string NickName { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public LoginViewModel()
        {
        }
    }
}
