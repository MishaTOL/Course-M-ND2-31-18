using Lab2.Domain.Contracts;
using Lab2.Domain.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service;

        public StudentController()
        {
            service = new StudentService();
        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentViewModel student)
        {
            var registeredStudent = service.AuthorizeStudent(student);
            Session["StudentId"] = registeredStudent.StudentId;
            Session["FirstName"] = registeredStudent.FirstName;
            Session["LastName"] = registeredStudent.LastName;
            return RedirectToAction("Index", "Post");
        }
    }
}