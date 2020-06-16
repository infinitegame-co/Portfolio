using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poolside.Models;
using Logic;
using DTO;

namespace Poolside.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserLogic _User;
        private readonly Conversions _Convert;
        public AccountController(UserLogic User)
        {
            _User = User;
            _Convert = new Conversions();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            //Debug.Print(loginViewModel.Email);
            //Debug.Print(loginViewModel.Password);
            AccountDTO account = _Convert.ConvertToAccountDTO(loginViewModel);
            AccountDTO user = _User.LogIn(account);
            if (user != null)
            {
                ViewBag.FakeLogin = true;
            }
            return View("../Home/Index", _Convert.ConvertToLoginViewModel(user));
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
            // _User.CreateAccount();
            return View("../Home/Index", loginViewModel);
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