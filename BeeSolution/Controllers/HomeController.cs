using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeeSolution.Models;
using Newtonsoft.Json;

namespace BeeSolution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bee()
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
        [HttpPost]
        public ActionResult Whack()
        {
            Hive myHive = (Hive)TempData["myHive"];
            if (myHive == null)
            {
                myHive = new Models.Hive();
            }
            myHive.HitBee();
            TempData["myHive"] = myHive;
            var str = JsonConvert.SerializeObject(myHive);
            return Json(str, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Bees()
        {
            Hive myHive = (Hive)TempData["myHive"];
            if (myHive == null)
            {
                myHive = new Models.Hive();
            }
            myHive.HitBee();
            TempData["myHive"] = myHive;
            var str = JsonConvert.SerializeObject(myHive);
            return Json(str, JsonRequestBehavior.AllowGet);
        }
    }
}