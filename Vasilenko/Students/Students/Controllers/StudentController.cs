using Newtonsoft.Json;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;

namespace Students.Controllers
{
    public class StudentController : Controller
    {
        private static int id;
        string path = @"d:\Students.json";
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public void Create(Student student)
        {

            if (!System.IO.File.Exists(path))
            {
                id = 1;
                student.ID = id;
                System.IO.File.WriteAllText(path, "[" + JsonConvert.SerializeObject(student) + "]");
            }
            else
            {
                id = id + 1; ;
                student.ID = id;
                string s = System.IO.File.ReadAllText(path);
                s = s.Remove(s.Length - 1, 1);
                System.IO.File.WriteAllText(path, s + "," + JsonConvert.SerializeObject(student) + "]");
            }
        }
        public ActionResult Read()
        {
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<Student> lstStudent = ser.Deserialize<List<Student>>(json);
                return View(lstStudent);
            }
            else
            {
                return Redirect("/Student/Create");
            }
                
        }
        [HttpGet]
        public ActionResult Delete()
        {
            if (System.IO.File.Exists(path))
            {
                return View();
            }
            else
            {
                return Redirect("/Student/Create");
            }
        }
        [HttpPost]
        public void Delete(Student student)
        {
            
                string json = System.IO.File.ReadAllText(path);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<Student> lstStudent = ser.Deserialize<List<Student>>(json);
                foreach (var s in lstStudent)
                {
                    if (s.ID == student.ID)
                    {
                        lstStudent.RemoveAt(student.ID - 1);
                        break;
                    }
                }
                System.IO.File.Delete(path);
                string temp = "[";
                foreach (var s in lstStudent)
                {
                    temp += "{" + @"""ID""" + ":\"" + s.ID.ToString() + "\", \"FirstName\":\"" + s.FirstName.ToString() + "\", \"LastName\":\"" + s.LastName.ToString() + "\"},";
                }
                temp = temp.Remove(temp.Length - 1, 1);
                temp += "]";
                System.IO.File.WriteAllText(path, temp);
        }
        [HttpGet]
        public ActionResult Update()
        {
            if (System.IO.File.Exists(path))
            {
                return View();
            }
            else
            {
                return Redirect("/Student/Create");
            }
        }
        [HttpPost]
        public ActionResult UpdateDetails(Student student)
        {
            List<Student> details = new List<Student>(); ;
            string json = System.IO.File.ReadAllText(path);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Student> lstStudent = ser.Deserialize<List<Student>>(json);
            foreach (var s in lstStudent)
            {
                if (s.ID == student.ID)
                {
                    details.Add(s);
                    break;
                }
                else
                {
                    throw new HttpException(404, "Student ID not found");
                }
            }
            return View(details);
        }
        [HttpPost]
        public void Save(Student student)
        {
            string json = System.IO.File.ReadAllText(path);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Student> lstStudent = ser.Deserialize<List<Student>>(json);
            foreach (var s in lstStudent)
            {
                if (s.ID == student.ID)
                {
                    lstStudent.Insert(student.ID - 1, student);
                    lstStudent.RemoveAt(student.ID);
                    break;
                }
            }

            System.IO.File.Delete(path);
            string temp = "[";
            foreach (var s in lstStudent)
            {
                temp += "{" + @"""ID""" + ":\"" + s.ID.ToString() + "\", \"FirstName\":\"" + s.FirstName.ToString() + "\", \"LastName\":\"" + s.LastName.ToString() + "\"},";
            }
            temp = temp.Remove(temp.Length - 1, 1);
            temp += "]";
            System.IO.File.WriteAllText(path, temp);
        }
    }


}

