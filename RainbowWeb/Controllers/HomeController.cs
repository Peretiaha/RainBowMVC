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
                ViewBag.ContactError = "Пользователь с такой почтой уже подписан на рассылку!";
                ViewBag.ContactSuccess = "Подписка оформленна!";

            }
            else if (Autification.IsRegstered(user))
            {

                if (Autification.UserStatus(user) == true)
                    return View("../Admin/AddCommand");  //Админ панель
                else return View("../Home/About");
            }
            else ViewBag.LoginError = "Invalid data";
            return View("../Home/Index");  // учетная запись пользователя
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