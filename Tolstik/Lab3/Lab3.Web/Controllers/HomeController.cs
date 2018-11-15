using Lab3.Data.Contracts.Repositories;
using Lab3.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = Container.Resolve<IStudentRepository>();
            ViewBag.Students = repo.FindAllStudents();
            return View();
        }
    }
}