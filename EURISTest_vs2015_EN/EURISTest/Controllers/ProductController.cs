using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURIS.Service;
using EURIS.Entities;
using System.Net;

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

        public ActionResult Edit(int? Id)
        {
           
            if (Id == null)
            {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int ID = Id.GetValueOrDefault();
            var model = productManager.GetProduct(ID);

            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
              if( productManager.UpdateProduct(product))
                {
                    return RedirectToAction("Index", "Product");
                }
            }

            return HttpNotFound();
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int ID = Id.GetValueOrDefault();
            var model = productManager.GetProduct(ID);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }


        public ActionResult Delete(int? Id)
        {
            int ID = Id.GetValueOrDefault();
            var model = productManager.GetProduct(ID);
            return View(model);
        }

        
        public ActionResult DeleteProduct(int id)
        {
            Product product = new Product();
            var pro = LocalDbEntities.Product.Find(id);
            if (productManager.Delete(pro))
            {
                return RedirectToAction("Index");
            }


            return Redirect("/Product/Delete/");


        }

    }
}
