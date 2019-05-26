using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RainbowWeb.Models;

namespace RainbowWeb.Controllers
{
    public class CommandController : Controller
    {
        // GET: Command
        [HttpGet]
        public ActionResult CommandList()
        {
            using (DbModel db = new DbModel())
            {
                ViewBag.Command = db.Commands.ToList();
                ViewBag.i = 1;
            }

                return View();
        }



        [HttpPost]
        public ActionResult CommandList(Commands command)
        {

            return View();
        }
    }
}