using Lab1.Models;
using Student.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        StudentService service = new StudentService();
        // GET: Student
        public ActionResult Index()
        {
            var model = service.GetList();
            return View(model);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetStudentById(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                service.Create(new StudentViewModel{
                    Name = Request.Form["Name"],
                    Surname = Request.Form["Surname"],
                    Course = int.Parse(Request.Form["Course"])
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View(service.GetStudentById(id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                service.Update(id, new StudentViewModel
                {
                    Name = Request.Form["Name"],
                    Surname = Request.Form["Surname"],
                    Course = int.Parse(Request.Form["Course"])
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.GetStudentById(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                service.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
