using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURIS.Service;
using EURIS.Entities;
using System.Data.Entity;
using EURIS.Entities.Model;

namespace EURIS.Test.Controllers
{
    public class HomeController : Controller
    {

         
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the EURIS Group ASP.NET MVC developer test application.";


            using (var ctx = new DbContextApp())
            {
                var stud = new Entities.Model.Product() { Code = "fff", Description = "test" };
                ctx.products.Add(stud);
                ctx.SaveChanges();
            };
               



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
