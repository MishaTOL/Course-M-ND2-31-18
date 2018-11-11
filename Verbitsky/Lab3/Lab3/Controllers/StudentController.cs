using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Contracts.Entities;
using Data.Contracts.Repositories;
using MyDependencyInjectionContainer;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public ActionResult Index()
        {
            return View(studentRepository.Read());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            studentRepository.Create(student);
            return View(student);
        }
        public ActionResult Update()
        {
            return View(studentRepository.Read());
        }
        [HttpPost]
        public ActionResult Update(Student student)
        {
            studentRepository.Update(student);
            return View(studentRepository.Read());
        }
        public ActionResult Delete()
        {
            return View(studentRepository.Read());
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            studentRepository.Delete(id);
            return View(studentRepository.Read());
        }
    }
}