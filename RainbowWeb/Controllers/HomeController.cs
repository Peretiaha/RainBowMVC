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
                if (AddContacts.Add(user)) ViewBag.ContactSuccess = "Подписка оформленна!";
                else
                ViewBag.ContactError = "Пользователь с такой почтой уже подписан на рассылку!";
                

            }
            else if (Autification.IsRegstered(user))
            {

                if (Autification.UserStatus(user) == true)
                    return View("../Admin/AddCommand");  //Админ панель
               
                else
                {
                    Users newuser = new Users();
                    using (DbModel db = new DbModel())
                    {
                        foreach (var i in db.Users)
                        {
                            if (user.Login == i.Login && user.Password == i.Password)
                                newuser = i;
                        }
                        return View("../Admin/UsersProfile", newuser);
                    }
                } 
            }
            else ViewBag.LoginError = "Invalid data";
            ModelState.Clear();
            return View("../Home/Index");  // учетная запись пользователя
        }

        public ActionResult About(Users user)
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.User = user;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}