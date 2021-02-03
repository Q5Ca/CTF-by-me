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
    public class Battle1Controller : Controller
    {
        public IActionResult Index()
        {
            Player player;
            OneHeadMonster monster;
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
                    player = JsonConvert.DeserializeObject<Player>(data, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    });
                }
                catch (Exception ex)
                {
                    Response.Cookies.Delete("player");
                    ViewData["mess"] = "Player data broke. Go back home and re-register";
                    ViewData["cont"] = false;
                    return View();
                }
            }
            if (Request.Cookies["monster"] == null)
            {
                monster = new OneHeadMonster();
                Response.Cookies.Append("monster", Base64.b64encode(JsonConvert.SerializeObject(monster)));
                ViewBag.player = player;
                ViewBag.monster = monster;
                ViewData["mess"] = "Battle begin";
                ViewData["cont"] = true;
                return View();
            }
            else
            {
                try
                {
                    String data = Base64.b64decode(Request.Cookies["monster"]);
                    monster = JsonConvert.DeserializeObject<OneHeadMonster>(data);
                }
                catch (Exception ex)
                {
                    Response.Cookies.Delete("player");
                    Response.Cookies.Delete("monster");
                    ViewData["mess"] = "Monster data broken. Re-register !!!";
                    ViewData["cont"] = false;
                    return View();
                }
            }
            int player_attack = player.attack();
            monster.Health -= player_attack;
            ViewData["player_atk"] = "You attack " + player_attack;
            if (monster.Health <= 0)
            {
                Response.Cookies.Delete("player");
                Response.Cookies.Delete("monster");
                ViewData["mess"] = "Monster died. You won !!! Go back to / to play again";
                ViewData["cont"] = false;
                return View();
            }
            int monster_attack = monster.attack();
            player.Health -= monster_attack;
            ViewData["monster_atk"] = "Monster attack " + monster_attack;
            if (player.Health <= 0)
            {
                Response.Cookies.Delete("player");
                Response.Cookies.Delete("monster");
                ViewData["mess"] = "You died. Monster won !!! Go back to / to play again";
                ViewData["cont"] = false;
                return View();
            }
            Response.Cookies.Append("player", Base64.b64encode(JsonConvert.SerializeObject(player)));
            Response.Cookies.Append("monster", Base64.b64encode(JsonConvert.SerializeObject(monster)));
            ViewBag.player = player;
            ViewBag.monster = monster;
            ViewData["cont"] = true;
            return View();
        }
    }
}