using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DBModels.Models;
using DBRepConUow.Context;

namespace DBRepConUow.Repositarys
{

    public class StudentRepositary : IRepositary<int, Student>
    {
        private ForumContext db;
        public StudentRepositary(ForumContext db)
        {
            this.db = db;
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public void Add(Student Model)
        {
            db.Students.Add(Model);
        }

        public void Delete(Student Model)
        {
            db.Students.Remove(Model);
        }

        public Student Get(int ID)
        {
            return db.Students.Find(ID);
        }

        public void Update(Student Model)
        {
            db.Entry(Model).State = EntityState.Modified;
        }

        public Student GetByEmail(string Email)
        {
            return db.Students.Where(p => p.Email == Email).FirstOrDefault();
        }

        public Student GetByNickName(string NickName)
        {
            return db.Students.Where(p => p.NickName == NickName).FirstOrDefault();
        }

        public Student Autentification(Student Model)
        {
            return db.Students.Where(
                p => (p.NickName == Model.NickName) && (p.Pass == Model.Pass)).FirstOrDefault();
        }
    }
}