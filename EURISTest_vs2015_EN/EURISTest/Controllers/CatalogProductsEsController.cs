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
    public class CatalogProductsEsController : Controller
    {
        private DbContextApp db = new DbContextApp();
        private ProductManager productManager = new ProductManager();


        // GET: CatalogProductsEs
        public ActionResult Index()
        {
            var model = productManager.GetMyCatlog();
            if (model == null)
            {
                return HttpNotFound();
            }
          return View(model);
        }

        // GET: CatalogProductsEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int ID =id.GetValueOrDefault();
            CatalogProductsE catalogProductsE = productManager.GetMyCatalog(ID);
            if (catalogProductsE == null)
            {
                return HttpNotFound();
            }
            return View(catalogProductsE);
        }

        // GET: CatalogProductsEs/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Description")] CatalogProductsE catalogProductsE)
        {
            if (ModelState.IsValid)
            {
                productManager.CreateNewMyCatalog(catalogProductsE);
                return RedirectToAction("Index");
            }

            return View(catalogProductsE);
        }

        // GET: CatalogProductsEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int ID = id.GetValueOrDefault();
            CatalogProductsE catalogProductsE = productManager.GetMyCatalog(ID);
            if (catalogProductsE == null)
            {
                return HttpNotFound();
            }
            return View(catalogProductsE);
        }

        // POST: CatalogProductsEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Description")] CatalogProductsE catalogProductsE)
        {
            if (ModelState.IsValid)
            {
                if (productManager.UpdateMyCatalog(catalogProductsE))
                {
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            return View(catalogProductsE);
        }

        // GET: CatalogProductsEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int ID = id.GetValueOrDefault();
            CatalogProductsE catalogProductsE = productManager.GetMyCatalog(ID);
            if (catalogProductsE == null)
            {
                return HttpNotFound();
            }
            return View(catalogProductsE);
        }

        // POST: CatalogProductsEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatalogProductsE catalogProductsE = productManager.GetMyCatalog(id);
            productManager.DeleteMyCatalog(catalogProductsE);
            return RedirectToAction("Index");
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
