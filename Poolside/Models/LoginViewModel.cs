using System;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Poolside.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}
