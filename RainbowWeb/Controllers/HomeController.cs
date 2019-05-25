using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RainbowWeb.Models;

namespace RainbowWeb.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            Users user = new Users();            
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(Users user)
        {
            if ((user.Login == "" || user.Login == null) && user.Email != "")
            {
                AddContacts.Add(user);
                ViewBag.ContactError = "Подписка оформлена!";
            }
            else if (Autification.IsRegstered(user))
            {

                if (Autification.UserStatus(user) == true)
                    return View("../Home/Contact", user);  //Админ панель
            }
            else ViewBag.LoginError = "Invalid data";
            return View("../Home/About");  // учетная запись пользователя
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}