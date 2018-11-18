using Domain.Contracts.ViewModels;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trial.Web.Controllers
{
    public class StudentController : Controller
    {
        private StudentService studentService;

        public StudentController()
        {
            studentService = new StudentService();
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(studentService.GetAll());
        }

        public ActionResult Delete(int id)
        {
            studentService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {           
            return View(studentService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            studentService.Update(student);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            studentService.Add(student);
            return RedirectToAction("Index");
        }
    }
}