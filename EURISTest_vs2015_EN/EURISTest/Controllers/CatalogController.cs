using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURIS.Entities;
using EURIS.Service;
using PagedList.Mvc;
using PagedList;

namespace EURISTest.Controllers
{
    public class CatalogController : Controller
    {
        private LocalDbEntities db = new LocalDbEntities();

        //
        // GET: /Catalog/

        public ActionResult Index(string sort, string search, int? page)
        {
           
            ViewData["CodeSortParm"] = String.IsNullOrEmpty(sort) ? "code_desc" : "";
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sort) ? "ID_desc" : "";
            ViewData["filterResult"] = null;
            ViewData["Result"] = null;


            if (search != null)
            {
                page = 1;
            }
            else
            {
               
            }
            var pageNumber = page ?? 1;

            //no matter what, this code is fill a container
            var model = db.Product.ToList();
            int pageSize = 3;


            //in search case 
            if (!string.IsNullOrEmpty(search))
            {
                var SearchViewResult = db.Product.Where(x => x.Code.Contains(search));
              
                if(SearchViewResult.Count() > 0)
                {
                    ViewData["Result"] = SearchViewResult.Count();
                    return View(SearchViewResult.ToList().ToPagedList(page ?? 1, pageSize));
                }
                else
                {
                    ViewData["Result"] = db.Product.Count();
                    ViewData["filterResult"] = 1;
                    return View(db.Product.ToList().ToPagedList(page ?? 1, pageSize));
                }
            }

            switch (sort)
            {
                case "code_desc":
                    model = model.OrderByDescending(x => x.Code).ToList();
                    break;

                case "ID_desc":
                    model = model.OrderByDescending(x => x.Id).ToList();
                    break;

                default:
                    model = model.OrderBy(x => x.Id).ToList();
                    break;
            }
            ViewData["Result"] = model.Count();
            return View(model.ToList().ToPagedList(page ?? 1, pageSize));
        }

        //
        // GET: /Catalog/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Catalog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Catalog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Catalog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Catalog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Catalog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Catalog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}