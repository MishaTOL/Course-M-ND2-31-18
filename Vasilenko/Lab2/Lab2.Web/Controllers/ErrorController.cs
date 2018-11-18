using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http404(string url)
        {
            Response.StatusCode = 404;
            ViewData["url"] = url;
            return View();
        }

    }
}