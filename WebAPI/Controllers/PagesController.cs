using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize()]
    public class PagesController : Controller
    {
        [Authorize(Roles = "tor")]
        public IActionResult Page1()
        {
            return View();
        }
        [Authorize(Roles = "Editor")]
        public IActionResult Page2()
        {
            return View();
        }
        [Authorize(Roles = "Moderator")]
        public IActionResult Page3()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Page4()
        {
            return View();
        }
    }
}