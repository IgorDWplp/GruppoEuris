using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURIS.Service;
using EURIS.Entities;

namespace EURISTest.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            ProductManager productManager = new ProductManager();
            List<Product> products = productManager.GetProducts();

            ViewBag.Products = products;

            return View();
        }

    }
}
