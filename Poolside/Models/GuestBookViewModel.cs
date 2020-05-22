using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poolside.Models
{
    public class GuestBookViewModel
    {
        public string UserNickName { get; set; }
        public string Message { get; set; }
        public DateTime PostDate { get; set; }
    }
}
