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
                    global.LatestMessage = "Logged in successfully";
                }
                else
                {
                    global.LatestMessage = "Couldn't log in: No user was found under that email";
                }
            }
            else
            {
                global.LatestMessage = "Couldn't log in: one or more fields left empty";
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
                global.LatestMessage = "Account" + account.NickName + " made successfully";

            }
            else
            {
                global.LatestMessage = "No account made, one or more fields were not valid";
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
            global.LatestMessage = "No password recovery email was sent.";
            return View("../Home/Index", global);
        }
    }
}