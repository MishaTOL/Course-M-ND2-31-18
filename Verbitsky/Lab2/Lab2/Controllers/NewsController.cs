using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models.ViewModels.News;
using Lab2.Models;
using AutoMapper;
using System.IdentityModel;

namespace Lab2.Controllers
{
    public class NewsController : Controller
    {
        private NewsStudentDbContext db = new NewsStudentDbContext();
        public NewsController()
        {
            db = new NewsStudentDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IndexStudentViewModel _student)
        {
            var user = db.Students
                .Where(a => a.FirstName == _student.FirstName && a.LastName == _student.LastName)
                .SingleOrDefault();
            if(user == null)
            {
                var student = Mapper.Map<IndexStudentViewModel, Student>(_student);
                db.Students.Add(student);
                db.SaveChanges();
                user = db.Students
                    .Where(a => a.FirstName == _student.FirstName && a.LastName == _student.LastName)
                    .SingleOrDefault();
            }
            Session["User"] = user;
            return RedirectToAction("Index", "Posts");
        }
    }
}