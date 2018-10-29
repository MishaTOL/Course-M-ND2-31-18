using Lab1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {      
        public ActionResult StudentList()
        {
            return View(ReadStudentsLibJson());
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {           
            var newListStudent = AddNewStudent(student);
            return View("StudentList", newListStudent);
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = ReadStudentsLibJson().Find(x => x.id == id);
            return View("EditStudent", student);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            var students = ReadStudentsLibJson();
            var studentEditable = students.Find(x => x.id == student.id);
            students.Remove(studentEditable);
            students.Add(student);
            WriteData(students);
            return View("StudentList", students);
        }

        public ActionResult DeleteStudent(int id)
        {
            List<Student> studentsFromFile = ReadStudentsLibJson();
            var delRow = studentsFromFile.Find(x => x.id == id);
            if (delRow != null)
            {
                studentsFromFile.Remove(delRow);
                WriteData(studentsFromFile);
            }
            return View("StudentList", studentsFromFile); 
        }


        private List<Student> ReadStudentsLibJson()
        {
            var studentsList = new List<Student>();

            using (var file = System.IO.File.OpenText(HostingEnvironment.MapPath("\\Files\\StudentsLib.json")))
            {
                 studentsList = JsonConvert.DeserializeObject<List<Student>>(file.ReadToEnd());
            }

            return studentsList;
        }
        
        private List<Student> AddNewStudent(Student student)
        {
            var studentsList = new List<Student>();
            studentsList = ReadStudentsLibJson();
            student.id = GenerateNewStudentId(studentsList);
            studentsList.Add(student);
            WriteData(studentsList);

            return studentsList;
        }

        private int GenerateNewStudentId(List<Student> students)
        {
            int maxId = 0;
            if (students.Count>0)
                maxId = students.Max(x=>x.id); 
            
            return ++maxId;
        }

        private void WriteData(List<Student> students)
        {
            System.IO.File.WriteAllText(HostingEnvironment.MapPath("\\Files\\StudentsLib.json"), JsonConvert.SerializeObject(students));
        }
    }
}