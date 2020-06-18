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
            GlobalViewModel global = new GlobalViewModel();
            if (ModelState.IsValid)
            {
                AccountDTO account = _Convert.ConvertToAccountDTO(loginViewModel);
                AccountDTO user = _User.LogIn(account);
                if (user != null)
                {
                    ViewBag.FakeLogin = true;
                    ViewBag.Nickname = user.NickName;
                    global.VMlogin = _Convert.ConvertToLoginViewModel(user);
                }
            }
            return View("../Home/Index", global);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(LoginViewModel loginViewModel)
        {
            GlobalViewModel global = new GlobalViewModel();
            if (ModelState.IsValid)
            {
                AccountDTO account = _Convert.ConvertToAccountDTO(loginViewModel);
                _User.CreateAccount(account);
            }
            return View("../Home/Index", global);
        }

        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forgot(LoginViewModel loginViewModel)
        {
            GlobalViewModel global = new GlobalViewModel();
            return View("../Home/Index", global);
        }
    }
}