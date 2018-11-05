using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        private DBContext db = new DBContext(@"D:\Projects\C#\Course-M-ND2-31-18\Verbitsky\Lab1\Lab1\App_Data\DB.json");
        public ActionResult Index()
        {
            return View(db.Read());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.Create(student);
            return View(student);
        }
        public ActionResult Update()
        {
            return View(db.Read());
        }
        [HttpPost]
        public ActionResult Update(Student student)
        {
            db.Update(student);
            return View(db.Read());
        }
        public ActionResult Delete()
        {
            return View(db.Read());
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.Delete(id);
            return View(db.Read());
        }
    }
}