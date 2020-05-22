using System;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Poolside.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
