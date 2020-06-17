using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public HomeController(ILogger<HomeController> logger, HomePageInteractions homePageInteractions)
        {
            this.homePageInteractions = homePageInteractions;
            _logger = logger;
        }

        public IActionResult Index()
        {
            homePageInteractions.GetAllGuestBooks();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
