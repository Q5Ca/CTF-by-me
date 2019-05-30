using System;
using System.Linq;
using System.Web.Mvc;
using lyrics.Models;

namespace lyrics.Controllers
{
    public class UserController : Controller
    {
        // Get: /Login
        public ActionResult Login()
        {
            if (Session["loggedin"] != null && Session["loggedin"].Equals(1))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return View();
            }
        }

        // Post: /Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (Session["loggedin"] != null && Session["loggedin"].Equals(1))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                using (UserDBContext db = new UserDBContext())
                {
                    var usr = db.Users.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["loggedin"] = 1;
                        Session["userid"] = usr.ID;
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    else
                    {
                        ViewBag.message = "Username or password incorrect";
                        return View();
                    }
                }
            }
        }

        // Get: /Register
        public ActionResult Register()
        {
            if (Session["loggedin"] != null && Session["loggedin"].Equals(1))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                return View();
            }
        }

        // Post: /Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (Session["loggedin"] != null && Session["loggedin"].Equals(1))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    using (UserDBContext db = new UserDBContext())
                    {
                        Random random = new Random();
                        user.LyricID = random.Next(0, 16);
                        var usr = db.Users.SingleOrDefault(u => u.Username == user.Username);
                        if (usr == null)
                        {
                            db.Users.Add(user);
                            db.SaveChanges();
                            ViewBag.message = "Username " + user.Username + " is successfully registered, let login and get a lyric :v";
                            return View();
                        }
                        else
                        {
                            ViewBag.message = "Username is already taken";
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.message = "Hmm. Something wrong...";
                    return View();
                }
            }
        }

        // Get: /Logout
        public ActionResult Logout()
        {
            if (Session["loggedin"] != null && Session["loggedin"].Equals(1))
            {
                Session["loggedin"] = 0;
                Session["userid"] = 0;
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        // Get: /UserLyric/ID
        public JsonResult UserLyric(int id)
        {
            if (Session["loggedin"] != null && Session["loggedin"].Equals(1))
            {
                using (UserDBContext db = new UserDBContext())
                {
                    var usr = db.Users.Find(id);
                    if (usr != null)
                    {
                        string Lyric;
                        switch (usr.LyricID)
                        {
                            case 0:
                                Lyric = "Lòng ta xin nguyện khắc tình nồng mê say";
                                break;
                            case 1:
                                Lyric = "Cớ sao anh cứ mong chờ vì anh đã yêu dại khờ";
                                break;
                            case 2:
                                Lyric = "Anh sẽ về,anh sẽ về. Nhưng không phải hôm nay.";
                                break;
                            case 3:
                                Lyric = "Tôi lạc quan giữa đám đông, nhưng khi 1 mình thì lại không";
                                break;
                            case 4:
                                Lyric = "Đời cho ta quá nhiều thứ, ta chưa cho đời được nhiều. Đến bây giờ vẫn chưa học được cách làm sao để lời được nhiều";
                                break;
                            case 5:
                                Lyric = "Sẽ luôn thật gần bên em. Sẽ luôn là vòng tay ấm êm. Sẽ luôn là người yêu em ";
                                break;
                            case 6:
                                Lyric = "Ai từng đã hứa sẽ bên anh và ko rời xa vòng tay anh . Em từng đã nói muốn đi xa ở nơi chỉ riêng có 2 chúng ta ";
                                break;
                            case 7:
                                Lyric = "Một là không nói dối, hai là ko nói dối nhiều lần";
                                break;
                            case 8:
                                Lyric = "Tôi vô tình là thế. Hay quên gọi về Mẹ";
                                break;
                            case 9:
                                Lyric = "Ngọn cỏ ven đường thôi mà làm sao với được mây...";
                                break;
                            case 10:
                                Lyric = "Em không thể biến mùa hạ thành đông. Như cũng không thể khiến anh về bên em.";
                                break;
                            case 11:
                                Lyric = "Đừng hỏi em vì sao, tình yêu ta úa màu. Đừng trách em vì sao, giấc mơ tàn mau. Đừng hỏi em vì sao, ngày đôi ta bắt đầu. Một chiếc hôn nồng sâu đã đưa ta về đâu.";
                                break;
                            case 12:
                                Lyric = "Người lạ ơi ! Xin hãy cho tôi mượn bờ vai. Tựa đầu gục ngã vì mỏi mệt quá";
                                break;
                            case 13:
                                Lyric = "Cục Sì Lầu Là Ông Bê Lắp";
                                break;
                            case 14:
                                Lyric = "Em mượn rượu tỏ tình đấy thì sao nào?";
                                break;
                            case 15:
                                Lyric = "Sao em hôn môi anh ta bằng son môi anh trả";
                                break;
                            case 1337:
                                Lyric = "BksEc{tA_laNg_Ta_LanG}";
                                break;
                            default:
                                Lyric = "How ???";
                                break;
                        }
                        return Json(new { username = usr.Username, lyric = Lyric }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { error = "That account haven't been registered :((" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return Json(new { error = "You haven't logged in :((" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}