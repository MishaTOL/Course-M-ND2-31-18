using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;

using System.IdentityModel;

namespace Lab2.Controllers
{
    public class NewsController : Controller
    {
        private NewsStudentDbContext db = new NewsStudentDbContext();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student _student)
        {
            var buf = db.Students
                .Where(a => a.FirstName == _student.FirstName && a.LastName == _student.LastName)
                .SingleOrDefault();
            if(buf == null)
            {
                db.Students.Add(_student);
                db.SaveChanges();
                buf = db.Students
                    .Where(a => a.FirstName == _student.FirstName && a.LastName == _student.LastName)
                    .SingleOrDefault();
            }
            Session["User"] = buf;
            return RedirectToAction("Index", "Posts");
        }
    }
}