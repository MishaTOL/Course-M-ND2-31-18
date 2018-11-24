using Lab1.core.Data;
using Lab1.core.Interface;
using Lab1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Student> repository = new StudentRepository();
        // GET: Home
        public ActionResult Index()
        {
            //
            IEnumerable<Student> students = repository.GetAll();
            //
            return View(students);
        }


        public ActionResult Create()
        {
            //
            Student student = new Student() { Age = 17, FirstName = "Alex", LastName = "M" };
            //
            return View(student);
        }

        [HttpPost]
        public ActionResult Create(Student newstudent)
        {
            //
            repository.Create(newstudent);
            //
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student student = repository.Get(id);

            return View(student);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            //
            repository.Delete(id);
            //
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Details(int id)
        {
            Student student = repository.Get(id);

            return View(student);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //
            Student student = repository.Get(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            //
            repository.Update(student);

            return RedirectToAction("Index", "Home");
        }
    }
}