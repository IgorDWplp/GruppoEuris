using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using EURIS.Entities;
using PagedList;
using Rotativa;
using Rotativa.MVC;

namespace EURISTest.Controllers
{
    public class CatalogController : Controller
    {
        private LocalDbEntities db = new LocalDbEntities();

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

        /// <summary>
        /// view just for PDF
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewProducts()
        {
            var model = db.Product.ToList();
            return View(model);
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("ViewProducts");
            return report;
        }



    }
}