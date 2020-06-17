using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poolside.Models
{
    public class GlobalViewModel
    {
        public GuestBookViewModel guestBookViewModel {get;set;}
        public IndexViewModel indexViewModel {get;set;}
        public LoginViewModel loginViewModel {get;set;}
        public ErrorViewModel errorViewModel {get;set;}
    }
}
