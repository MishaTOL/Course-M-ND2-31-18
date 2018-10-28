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
        private DBContext db = new DBContext(@"D:\Projects\C#\ASP It-Academy\Course-M-ND2-31-18\Verbitsky\Lab1\Lab1\App_Data\DB.json");
        public ActionResult Index() => View(db.Read());
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.Create(student);
            return View(student);
        }
        public ActionResult Update() => View(db.Read());
        [HttpPost]
        public ActionResult Update(Student student)
        {
            db.Update(student);
            return View(db.Read());
        }
        public ActionResult Delete() => View(db.Read());
        [HttpPost]
        public ActionResult Delete(uint id)
        {
            db.Delete(id);
            return View(db.Read());
        }
    }
}