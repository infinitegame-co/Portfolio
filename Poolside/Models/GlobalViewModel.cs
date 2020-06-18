using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Access;
using Logic;

namespace Poolside.Models
{
    public class GlobalViewModel
    {
        public GuestBookViewModel VMguestBook { get; set; }
        public IndexViewModel VMindex { get; set; }
        public LoginViewModel VMlogin { get; set; }
        public ErrorViewModel VMerror { get; set; }

        public GlobalViewModel()
        {
            VMindex = VMindex == null ? GenNewFilledIndexList() : VMindex;
        }

        private IndexViewModel GenNewFilledIndexList()//generates a new instance of indexviewmodel and fills it with guestbook entries
        {
            IndexViewModel ivm = new IndexViewModel();
            Conversions con = new Conversions();
            HomePageInteractions hpi = new HomePageInteractions(new PortfolioAccess(), new GuestBookAccess());
            ivm.GuestBookEntries = con.ConvertToGuestBookViewModelList(hpi.GetAllGuestBooks());
            return ivm;
        }
    }
}
