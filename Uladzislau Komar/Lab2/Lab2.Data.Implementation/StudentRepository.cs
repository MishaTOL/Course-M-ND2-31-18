using Lab2.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Data.Implementation
{
    public class StudentRepository
    {
        public void Create(StudentEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Students.Add(entity);
                database.SaveChanges();
            }
        }
        public StudentEntity Read(int id)
        {
            using (var database = new DBLab2Context())
            {
                return database.Students.Find(id);
            }
        }
        public StudentEntity Read(StudentEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                StudentEntity output = null;
                foreach (var item in database.Students)
                {
                    if ((item.FirstName == entity.FirstName) && (item.LastName == entity.LastName))
                    {
                        output = item;
                        break;
                    }
                }
                return output;
            }
        }
        public ICollection<StudentEntity> Read()
        {
            using (var database = new DBLab2Context())
            {
                return database.Set<StudentEntity>().ToList();
            }
        }
        public void Update(StudentEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Students.Attach(entity);
                var entry = database.Entry(entity);
                entry.Property(e => e.FirstName).IsModified = true;
                entry.Property(e => e.LastName).IsModified = true;
                database.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var database = new DBLab2Context())
            {
                var oldEntity = new StudentEntity { StudentId = id };
                database.Students.Attach(oldEntity);
                database.Students.Remove(oldEntity);
                database.SaveChanges();
            }
        }
        public void Delete(StudentEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Students.Attach(entity);
                database.Students.Remove(entity);
                database.SaveChanges();
            }
        }
    }
}
