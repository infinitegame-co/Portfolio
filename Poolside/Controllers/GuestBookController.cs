using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Poolside.Controllers
{
    public class GuestBookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}