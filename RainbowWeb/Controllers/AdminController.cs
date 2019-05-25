using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RainbowWeb.Models;

namespace RainbowWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult AddCommand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCommand(Commands command, HttpPostedFileBase uploadImage)
        {
            if (AddOrRevisionCommands.Add(command, uploadImage))
                return View(command);
            else ViewBag.ErrorImg = "Не удаолсь загрузить новую комманду";

            

            return View();
        }
    }
}