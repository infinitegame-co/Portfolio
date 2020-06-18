using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poolside.Models;

namespace Poolside.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomePageInteractions homePageInteractions;
        private readonly AdminInteractions adminInteractions;
        private readonly Conversions conversion;
        public HomeController(ILogger<HomeController> logger, HomePageInteractions homePageInteractions, AdminInteractions adminInteractions)
        {
            this.homePageInteractions = homePageInteractions;
            this.adminInteractions = adminInteractions;
            conversion = new Conversions();
            _logger = logger;
        }

        public IActionResult Index()
        {
            GlobalViewModel model = new GlobalViewModel();
            IndexViewModel indexmodel = new IndexViewModel();
            indexmodel.GuestBookEntries = conversion.ConvertToGuestBookViewModelList(homePageInteractions.GetAllGuestBooks());
            indexmodel.GuestBookEntries.Reverse();
            model.VMindex = indexmodel;
            model.LatestMessage = "Welcome, please Sign In";
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult DeleteEntry(GlobalViewModel glob)
        {
            GuestBookDTO DTO = conversion.ConvertToGuestBookDTO(glob.VMguestBook);
            adminInteractions.DeleteGuestBookEntry(DTO);
            GlobalViewModel model = new GlobalViewModel();
            model.LatestMessage = "Guestbook entry deleted succesfully";
            return View("../Home/Index", model);
        }
    }
}
