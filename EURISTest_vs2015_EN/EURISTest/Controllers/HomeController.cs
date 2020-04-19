using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURIS.Service;
using EURIS.Entities;
using EURIS.Entities.Model;

namespace EURIS.Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // DbContextApp dbContextApp = new DbContextApp();
            LocalDbEntities LocalDbEntities = new LocalDbEntities();
            SeedDB seedDB = new SeedDB();
            seedDB.SeedData(LocalDbEntities);


            ViewBag.Message = "Upravo ste unjeli proizvode!";
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your app description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

    }
}
