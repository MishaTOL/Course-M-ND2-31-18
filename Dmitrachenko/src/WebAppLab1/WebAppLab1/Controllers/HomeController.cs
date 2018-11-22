using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppLab1.Models;

namespace WebAppLab1.Controllers
{
    public class HomeController : Controller
    {
        public List<Students> students = new List<Students>();

        public HomeController()
        {
            //d:\VS2017\Projects\WebAppLab1\WebAppLab1\JsonFiles\Students.json
            string fileName = System.Web.HttpContext.Current.Request.MapPath(@"~/JsonFiles/Students.json");

            if (!System.IO.File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(students));
                }
            }

            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                string text = "";
                text = sr.ReadToEnd();
                if (text.Any())
                {
                    students = JsonConvert.DeserializeObject<List<Students>>(text);
                }
                else
                {
                    students.Add(new Students { Id = 1, FirstName = "Имя", LastName = "Фамилия" });
                }
            }
        }

        public ActionResult Index()
        {
            string studentsToJson = JsonConvert.SerializeObject(students);
            List<Students> jsonToStudents = JsonConvert.DeserializeObject<List<Students>>(studentsToJson);

            ViewBag.Students = students;
            ViewBag.StudentsToJson = studentsToJson;
            ViewBag.JsonToStudents = jsonToStudents;

            return View();
        }

        public ActionResult Create()
        {
            if (students.Count != 0)
            {
                int maxId = students.Select(s => s.Id).Max();
                var std = students.Where(s => s.Id == maxId).FirstOrDefault();
                std.Id++;
                std.FirstName = "";
                std.LastName = "";
                return View(std);
            }
            else
            {
                Students std = new Students()
                {
                    Id = 1,
                    FirstName = "",
                    LastName = ""
                };
                return View(std);
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, FirstName, LastName")] Students std)
        {
            students.Add(new Students
            {
                Id = std.Id,
                FirstName = std.FirstName,
                LastName = std.LastName
            });
            string fileName = System.Web.HttpContext.Current.Request.MapPath(@"~/JsonFiles/Students.json");
            using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(JsonConvert.SerializeObject(students));
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var std = students.Where(s => s.Id == Id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, FirstName, LastName")] Students std)
        {
            students.Where(s => s.Id == std.Id).FirstOrDefault().FirstName = std.FirstName;
            students.Where(s => s.Id == std.Id).FirstOrDefault().LastName = std.LastName;
            string fileName = System.Web.HttpContext.Current.Request.MapPath(@"~/JsonFiles/Students.json");
            using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(JsonConvert.SerializeObject(students));
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            var std = students.Where(s => s.Id == Id).FirstOrDefault();
            return View(std);
        }

        public ActionResult Delete(int Id)
        {
            var std = students.Where(s => s.Id == Id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, FirstName, LastName")] Students std)
        {
            var str = students.Where(s => s.Id == std.Id).FirstOrDefault();
            if (str != null)
                students.Remove(str);

            string fileName = System.Web.HttpContext.Current.Request.MapPath(@"~/JsonFiles/Students.json");
            using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(JsonConvert.SerializeObject(students));
            }
            return RedirectToAction("Index");
        }
    }
}