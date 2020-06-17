using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poolside.Models;

namespace Poolside.Controllers
{
    public class GuestBookController : Controller
    {
        public IActionResult GuestBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuestBook(GuestBookViewModel guestBook)
        {
            DateTime now = DateTime.Now;
            guestBook.PostDate = new DateTime(1997, now.Month, now.Day,now.Hour,now.Minute,now.Second);
            return View("../Home/Index");
        }
    }
}