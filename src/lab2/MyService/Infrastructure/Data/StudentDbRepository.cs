using Lab2.Models.db;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Data
{
    public class StudentDbRepository : IStudentDbRepository<Studentdb>
    {
        DataContext db;

        public StudentDbRepository()
        {
            db = new DataContext();
        }
        public void Create(Studentdb item)
        {
            db.Students.Add(item);
        }

        public void Delete(int id)
        {
            Studentdb studentdb = db.Students.Find(id);
            db.Students.Remove(studentdb);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
        public Studentdb Get(int id)
        {
            return db.Students.Find(id);
        }
        public Studentdb Get(Studentdb student)
        {
            IEnumerable<Studentdb>  students  = db.Students.ToList();
            Studentdb studentdb = students.Where(s => s.FirstName == student.FirstName).Where(k => k.LastName == student.LastName).FirstOrDefault();
            return studentdb;
        }

        public IEnumerable<Studentdb> GetAll()
        {
            return db.Students.ToList();
        }

        public IEnumerable<Studentdb> GetAll(int PostId)
        {
            throw new NotImplementedException();
        }



        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Studentdb item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}