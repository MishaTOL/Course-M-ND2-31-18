using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class StudentFileRepository : IDisposable, IRepository
    {
        string fileName = System.Web.HttpContext.Current.Request.MapPath(@"~/JsonFiles/Students.json");

        public List<Student> db = new List<Student>();

        public void Save(Student student)
        {
            //db.Students.Add(student);
            //db.SaveChanges();
        }

        public IEnumerable<Student> List()
        {
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                string text = "";
                text = sr.ReadToEnd();
                if (text.Any())
                {
                    db = JsonConvert.DeserializeObject<List<Student>>(text);
                }
                return db;
            }
        }

        public Student Get(int id)
        {
            return db.Find(s => s.StudentId == id);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Clear();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
