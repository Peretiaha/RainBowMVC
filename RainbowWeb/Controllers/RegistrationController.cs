using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RainbowWeb.Models;

namespace RainbowWeb.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult RegistrationView()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationView(Users user)
        {

            if (Registration.Add(user))
            {
                ViewBag.Success = "Пользователь успешно зарегестрирован!";
                return View();
            }

            else ViewBag.ErrorMessage = "Такой пользователь уже существует!";
            return View();
        }

    }
}