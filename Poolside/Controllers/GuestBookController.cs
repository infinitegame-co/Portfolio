﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Poolside.Models;

namespace Poolside.Controllers
{
    public class GuestBookController : Controller
    {
        private readonly UserInteractions userInteractions;
        private readonly Conversions conversions;
        public GuestBookController(UserInteractions userInteractions)
        {
            this.userInteractions = userInteractions;
            conversions = new Conversions();
        }
        public IActionResult GuestBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuestBook(GuestBookViewModel guestBook)
        {
            GlobalViewModel model;
            if (ModelState.IsValid)
            {
                DateTime now = DateTime.Now;
                guestBook.PostDate = new DateTime(1997, now.Month, now.Day, now.Hour, now.Minute, now.Second);
                GuestBookDTO dto = conversions.ConvertToGuestBookDTO(guestBook);
                userInteractions.WriteInGuestBook(dto);
                model = new GlobalViewModel();
                model.LatestMessage = "Successfully written in guestbook";
            }
            else
            {
                model = new GlobalViewModel();
                model.LatestMessage = "Couldn't write in guestbook";
            }
            return View("../Home/Index", model);

        }
    }
}