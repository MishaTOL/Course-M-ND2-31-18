using Laba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba1.Controllers
{
    public class HomeController : Controller
    {
        private StudentRepository _repository;

        public HomeController()
        {
            _repository = new StudentRepository();
        }

        public ActionResult Index()
        {
            return View(_repository.Get());
        }

        public ActionResult Create()
        {
            return View(_repository.Initialize());
        }
        [HttpPost]
        public ActionResult Create(Student record)
        {
            _repository.Add(record);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int studentId)
        {
            return View(_repository.Get().FirstOrDefault(s => s.StudentId == studentId));
        }

        public ActionResult Delete(int studentId)
        {
            _repository.Remove(studentId);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int studentId)
        {
            return View(_repository.Get().FirstOrDefault(s => s.StudentId == studentId));
        }
        [HttpPost]
        public ActionResult Edit(Student record)
        {
            _repository.Edit(record);
            return RedirectToAction("Index");
        }
    }
}