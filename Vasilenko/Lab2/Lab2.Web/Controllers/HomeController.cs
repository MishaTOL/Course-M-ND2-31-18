using Lab2.Business.Abstraction;
using Lab2.Business.Abstraction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService studentService;

        public HomeController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public ActionResult Index()
        {
            return Json(studentService.GetStudents(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(Student student)
        {
            var studentId=studentService.AddStudent(student);
            RedirectToAction("Posts", "Post");
            return Json(this.studentService.GetStudents(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id, string name, string lastname)
        {
            studentService.UpdateStudent(new Student() { Id = id, FirstName = name, LastName = lastname });
            return Json(this.studentService.GetStudents(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Remove(int id)
        {
            studentService.DeleteStudent(id);
            return Json(this.studentService.GetStudents(), JsonRequestBehavior.AllowGet);
        }
    }
}