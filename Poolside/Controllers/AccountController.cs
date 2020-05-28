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
            return View();
        }

        [HttpPost]
        public IActionResult LoginLogin(LoginViewModel loginViewModel)
        {
            Debug.Print(loginViewModel.Email);
            Debug.Print(loginViewModel.Password);
            return View();
        }


        [HttpPost]
        public IActionResult LoginRegister(LoginViewModel loginViewModel)
        {
            Debug.Print(loginViewModel.Email + "A");
            Debug.Print(loginViewModel.Password + "A");
            return View();
        }


    }
}