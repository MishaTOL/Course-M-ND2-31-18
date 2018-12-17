using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepository = studentRepo;
        }
        // GET: Student
        public ActionResult Index()
        {
            return View(_studentRepository.GetStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = _studentRepository.GetStudent(id);
            return student != null ? View(student) : View("Error");
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new Student());
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                _studentRepository.Create(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = _studentRepository.GetStudent(id);
            return student != null ? View(student) : View("Error");
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                _studentRepository.Update(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = _studentRepository.GetStudent(id);
            return student != null ? View(student) : View("Error");
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            try
            {
                _studentRepository.Delete(student.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
