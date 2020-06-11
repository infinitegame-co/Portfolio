using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poolside.Models;

namespace Poolside.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            //Debug.Print(loginViewModel.Email);
            //Debug.Print(loginViewModel.Password);
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginViewModel loginViewModel)
        {
            //Debug.Print(loginViewModel.Email + "A");
            //Debug.Print(loginViewModel.Password + "A");
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forgot(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}