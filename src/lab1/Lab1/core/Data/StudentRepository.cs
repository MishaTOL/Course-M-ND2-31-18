
using Lab1.core.Interface;
using Lab1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.core.Data
{
    public class StudentRepository : IRepository<Student>
    {

        string file_path = System.Web.HttpContext.Current.Server.MapPath("~/Files/Students.json");
        public List<Student> students { get; set; }


        public void Create(Student item)
        {
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            //
            int id = students.Count() == 0 ? 1 : students.Max(s => s.ID);
            //
            item.ID = students.Count() == 0 ? 1 : id + 1;
            //
            students.Add(item);
            //
            System.IO.File.WriteAllText(file_path, JsonConvert.SerializeObject(students));
        }

        public void Delete(int id)
        {
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            // 
            List<Student> newstudents = new List<Student>();
            //
            foreach (var student in students)
            {
                if (student.ID != id) newstudents.Add(student);
            }
            //
            System.IO.File.WriteAllText(file_path, JsonConvert.SerializeObject(newstudents));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            //
            Student student = students.Where(s => s.ID == id).First();
            //
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            List<Student>  students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            return students;
        }

        public void Save()
        {
            System.IO.File.WriteAllText(file_path, JsonConvert.SerializeObject(students));
        }

        public void Update(Student newstudent)
        {
            //
            List<Student> students = System.IO.File.Exists(file_path) ? JsonConvert.DeserializeObject<List<Student>>(System.IO.File.ReadAllText(file_path)) : new List<Student>();
            // 
            List<Student> newstudents = new List<Student>();
            //
            foreach (var student in students)
            {
                if (student.ID != newstudent.ID) newstudents.Add(student);
                else newstudents.Add(newstudent);
            }
            //
            System.IO.File.WriteAllText(file_path, JsonConvert.SerializeObject(newstudents));
        }
    }
}