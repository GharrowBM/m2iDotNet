﻿using Microsoft.AspNetCore.Mvc;

namespace ContactAspNetCore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult List2()
        {
            //return View("List");
            return View("~/Views/Contact/List.cshtml");
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }
    }
}