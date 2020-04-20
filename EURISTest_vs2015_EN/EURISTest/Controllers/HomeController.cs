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


            using (LocalDbEntities LocalDbEntities = new LocalDbEntities())
            {
                var check = LocalDbEntities.Product.Where(x => x.Id > 0).FirstOrDefault();
                if(check == null)
                {
                    SeedDB seedDB = new SeedDB();
                    seedDB.SeedData(LocalDbEntities);
                    ViewBag.Message = "Upravo ste unjeli proizvode!";
                }
            }
            ViewBag.Message = "Hello";
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
