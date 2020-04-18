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
        ProductManager productManager = new ProductManager();
        LocalDbEntities LocalDbEntities = new LocalDbEntities();
        //
        // GET: /Product/

        public ActionResult Index()
        {
            List<Product> products = productManager.GetProducts();
            ViewBag.Products = products;
            return View();

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                productManager.CreateNew(pro);
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var model = productManager.GetProduct(Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id)
        {
            var model = productManager.GetProduct(Id);
            return View(model);
        }

    }
}
