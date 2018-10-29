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


        // GET: Home
        public ActionResult Index()
        {
            //
            string file_path = Server.MapPath("~/Files/Students.json");
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            //
            return View(students);
        }


        public ActionResult Create()
        {
            //
            Student student = new Student() { Age = 17, FirstName = "Alex", LastName = "M" };
            //
            return View(new Student() { Age = student.Age, FirstName = student.FirstName, LastName = student.LastName });
        }

        [HttpPost]
        public ActionResult Create(Student newstudent)
        {
            //
            string file_path = Server.MapPath("~/Files/Students.json");
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            //
            int id = students.Count() == 0 ? 1 : students.Max(s => s.ID);
            //
            newstudent.ID = students.Count() == 0 ? 1 : id + 1;
            //
            //newstudent.ID = id++;
            //
            students.Add(newstudent);
            //
            System.IO.File.WriteAllText(file_path, JsonConvert.SerializeObject(students));

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            string file_path = Server.MapPath("~/Files/Students.json");
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            //

            Student student = students.Where(s => s.ID == id).First();

            return View(student);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            //
            string file_path = Server.MapPath("~/Files/Students.json");
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            //
            List<Student> newstudents = new List<Student>();

            foreach (var item in students)
            {
                if (item.ID != id) newstudents.Add(item);
            }
            //
            System.IO.File.WriteAllText(file_path, JsonConvert.SerializeObject(newstudents));
            //
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Details(int id)
        {
            string file_path = Server.MapPath("~/Files/Students.json");
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            //

            Student student = students.Where(s => s.ID == id).First();

            return View(student);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            string file_path = Server.MapPath("~/Files/Students.json");
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            //

            Student editstudent = students.Where(s => s.ID == id).First();

            return View(editstudent);
        }
        [HttpPost]
        public ActionResult Edit(Student editstudent)
        {
            //
            string file_path = Server.MapPath("~/Files/Students.json");
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            // 
            List<Student> newstudents = new List<Student>();
            //
            foreach (var item in students)
            {
                if (item.ID != editstudent.ID) newstudents.Add(item);
                else newstudents.Add(editstudent);
            }
            //
            System.IO.File.WriteAllText(file_path, JsonConvert.SerializeObject(newstudents));

            return RedirectToAction("Index", "Home");
        }
    }
}