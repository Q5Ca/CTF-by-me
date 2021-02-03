using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication3.Helpers;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class Battle2Controller : Controller
    {
        public IActionResult Index()
        {
            VipPlayer player;
            TwoHeadMonster monster;
            if (Request.Cookies["player"] == null)
            {
                ViewData["mess"] = "U not registered. Go back home and re-register";
                ViewData["cont"] = false;
                return View();
            }
            else
            {
                try
                {
                    String data = Base64.b64decode(Request.Cookies["player"]);
                    player = JsonConvert.DeserializeObject<VipPlayer>(data);
                }
                catch (Exception ex)
                {
                    Response.Cookies.Delete("player");
                    ViewData["mess"] = "Player data broke. Go back home and re-register";
                    ViewData["cont"] = false;
                    return View();
                }
            }
            ViewData["comment_xyz"] = "Now players can have sword. It'll be more fun. But I dont have time to code now. So sad :(";
            ViewData["comment_xyz1"] = "BTW if u are looking for flag, dont focus on this feature. I just put it here to make color :)) Seriouly !!!";
            ViewData["icon_path"] = player.swordIconPath;
            return View();
        }
    }
}