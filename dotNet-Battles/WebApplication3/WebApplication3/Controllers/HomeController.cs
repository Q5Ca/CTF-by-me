using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using Newtonsoft.Json;
using WebApplication3.Helpers;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            Response.Cookies.Delete("monster");
            Response.Cookies.Delete("player");
            return View();
        }

        [HttpPost]
        public IActionResult Index(String player_name)
        {
            Player player = new Player();
            player.Name = player_name;
            String data = JsonConvert.SerializeObject(player);
            data = Base64.b64encode(data);
            Response.Cookies.Append("player", data);
            ViewData["mess"] = "Register success, go for battles !!!";
            return View();
        }
    }
}
