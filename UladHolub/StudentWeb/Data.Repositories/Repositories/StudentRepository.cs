using Data.Contracts.Entities;
using Data.Contracts.Repositories;
using Data.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private StudentContext dataBase;

        public StudentRepository(StudentContext context)
        {
            dataBase = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return dataBase.Students;
        }
        
        public Student Get(int id)
        {
            return dataBase.Students.Find(id);
        }
        
        public void Create(Student student)
        {
            dataBase.Students.Add(student);
        }

        public void Update(Student student)
        {
            dataBase.Entry(student).State = EntityState.Modified;
        }
        
        public IEnumerable<Student> Find(Func<Student, Boolean> predicate)
        {
            return dataBase.Students.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Student student = dataBase.Students.Find(id);

            if (student != null) { dataBase.Students.Remove(student); }
        }
    }
}
