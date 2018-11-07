using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba2.Controllers
{
    public class HomeController : Controller
    {
        private int studentId;

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            ReaderUser();
            if (studentId == 0)
                return RedirectToAction("Index", "Student");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ReaderUser();
            if (studentId == 0)
                return RedirectToAction("Index", "Student");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ReaderUser();
            if (studentId == 0)
                return RedirectToAction("Index", "Student");
            return View();
        }

        private void ReaderUser()
        {
            string ss = (Session["StudentId"]??"0").ToString();
            int.TryParse(ss, out studentId);
        }
    }
}