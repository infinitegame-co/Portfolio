using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poolside.Models
{
    public class GuestBookViewModel
    {
        [Required(ErrorMessage="Please enter a nickname before posting")]
        public string UserNickName { get; set; }
        [Required(ErrorMessage = "Please enter a message before posting")]
        public string Message { get; set; }
        public DateTime PostDate { get; set; }
    }
}
