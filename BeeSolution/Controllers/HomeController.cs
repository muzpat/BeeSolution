using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeeSolution.Models;

namespace BeeSolution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        

        [HttpPost]
        public ActionResult HitBees()
        {
            Hive myHive = (Hive)TempData["myHive"];
            myHive.HitBee();
            TempData["myHive"] = myHive;
            return View("Bees", myHive);
        }
        public ActionResult StartBees()
        {
            Hive myHive = new Hive();
            TempData["myHive"] = myHive;
            return View("Bees", myHive);
        }
    }
}