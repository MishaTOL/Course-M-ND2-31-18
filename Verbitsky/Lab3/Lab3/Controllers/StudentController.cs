using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Contracts.Entities;
using Domain.Contracts.Services;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        public ActionResult Index()
        {
            return View(studentService.Read());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            studentService.Create(student);
            return View(student);
        }
        public ActionResult Update()
        {
            return View(studentService.Read());
        }
        [HttpPost]
        public ActionResult Update(Student student)
        {
            studentService.Update(student);
            return View(studentService.Read());
        }
        public ActionResult Delete()
        {
            return View(studentService.Read());
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            studentService.Delete(id);
            return View(studentService.Read());
        }
    }
}