using Lab1.Models;
using Lab1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        StudentService studentService = new StudentService();
        // GET: Student
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentService.AddNewStudent(student);
                return RedirectToAction("Show");
            }
            return View("Create");
        }

        public ActionResult Show()
        {
            studentService.InitializeDataBase();
            var students = studentService.StudentList;
            return View(students);
        }

        [DeleteUpdate]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            studentService.InitializeDataBase();
            studentService.DeleteById(id);
            return RedirectToAction("Show");
        }

        [DeleteUpdate]
        [HttpPost]
        public ActionResult Update(int id)
        {
            var student = studentService.FindById(id);
            return View("Change", student);
        }

        [HttpPost]
        public ActionResult Change(Student student)
        {
            studentService.ChangeStudent(student);
            return RedirectToAction("Show");
        }
    }
}