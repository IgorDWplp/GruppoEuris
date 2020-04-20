using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EURIS.Entities.Model;
using EURIS.Service;

namespace EURISTest.Controllers
{
    public class ProductEsController : Controller
    {
        private DbContextApp db = new DbContextApp();
        private ProductManager productManager = new ProductManager();

        // GET: ProductEs
        public ActionResult Index()
        {
            var model = productManager.GetMyProducts();
            var checkCatalog = db.catalogProductEs.ToList();
          
            if(model == null || checkCatalog.Count < 1)
            {
                return HttpNotFound();
            }
            ViewBag.Category = db.catalogProductEs.ToList();
            return View(model);
        }

        // GET: ProductEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int ID = id.GetValueOrDefault();
            ProductE productE = productManager.GetMyProduct(ID);
            if (productE == null)
            {
                return HttpNotFound();
            }
            return View(productE);
        }

        // GET: ProductEs/Create
        public ActionResult Create()
        {
            var Catalog_lst = db.catalogProductEs.ToList();
            ViewBag.List = Catalog_lst;
            return View();
        }

        // POST: ProductEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Description,fk_catalogID")] ProductE productE)
        {
            if (ModelState.IsValid)
            {
                productManager.CreateNewMyProduct(productE);
                return RedirectToAction("Index");
            }

            return View(productE);
        }

        // GET: ProductEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int ID = id.GetValueOrDefault();
            ProductE productE = productManager.GetMyProduct(ID);
            if (productE == null)
            {
                return HttpNotFound();
            }

            var Catalog_lst = db.catalogProductEs.ToList();
            ViewBag.List = Catalog_lst;

            return View(productE);
        }

        // POST: ProductEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Description,fk_catalogID")] ProductE productE)
        {
            if (ModelState.IsValid)
            {
                productManager.UpdateMyProduct(productE);
                return RedirectToAction("Index");
            }
            return View(productE);
        }

        // GET: ProductEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int ID = id.GetValueOrDefault();
            ProductE productE = productManager.GetMyProduct(ID);

            if (productE == null)
            {
                return HttpNotFound();
            }
            return View(productE);
        }

        // POST: ProductEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductE productE = productManager.GetMyProduct(id);
            if (productManager.DeleteMyProduct(productE))
            {
                return RedirectToAction("Index");
            }
            return HttpNotFound();
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
