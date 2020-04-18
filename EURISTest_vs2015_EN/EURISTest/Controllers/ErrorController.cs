using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EURISTest.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult NotFound()
        {
            var statusCode = (int)System.Net.HttpStatusCode.NotFound;
            Response.StatusCode = statusCode;
            Response.TrySkipIisCustomErrors = true;
            HttpContext.Response.StatusCode = statusCode;
            HttpContext.Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult ErrorR()
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

    }
}
