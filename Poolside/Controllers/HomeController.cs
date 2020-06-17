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
        private readonly Conversions conversion;
        public HomeController(ILogger<HomeController> logger, HomePageInteractions homePageInteractions)
        {
            this.homePageInteractions = homePageInteractions;
            conversion = new Conversions();
            _logger = logger;
        }

        public IActionResult Index()
        {
            GlobalViewModel model = new GlobalViewModel();
            IndexViewModel indexmodel = new IndexViewModel();
            List<GuestBookDTO> res = homePageInteractions.GetAllGuestBooks();

            foreach (GuestBookDTO gb in res)
            {
                indexmodel.GuestBookEntries.Add(conversion.ConvertToGuestBookViewModel(gb));
            }
            model.indexViewModel = indexmodel;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
