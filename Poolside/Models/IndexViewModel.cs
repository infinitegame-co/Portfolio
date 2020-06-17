using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poolside.Models
{
    public class IndexViewModel
    {
        public List<GuestBookViewModel> GuestBookEntries { get; set; }

        public IndexViewModel()
        {
            GuestBookEntries = new List<GuestBookViewModel>();
        }
    }
}
