using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class HihiNothingHereController : Controller
    {
        public IActionResult Index(String view)
        {
            ViewData["comment_xyz"] = "Just my test function. Pls dont use it :(";
            return View(view + ".hihi");
        }
    }
}