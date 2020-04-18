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
            DbContextApp dbContextApp = new DbContextApp();
            ViewBag.Message = "Welcome to the EURIS Group ASP.NET MVC developer test application.";
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
