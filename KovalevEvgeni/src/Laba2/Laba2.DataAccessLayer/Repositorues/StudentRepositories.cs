using Laba2.DataAccessLayer.EF;
using Laba2.DataAccessLayer.Entity;
using Laba2.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.DataAccessLayer.Repositorues
{
    public class StudentRepositories : IRepository<Student>
    {
        private StudentDbContext dataBaseContext;

        public StudentRepositories(StudentDbContext dataBase)
        {
            dataBaseContext = dataBase;
        }

        public void Create(Student item)
        {
            dataBaseContext.Students.Add(item);
        }

        public void Delete(int recordId)
        {
            Student student = GetRecord(recordId);
            if (student != null)
                dataBaseContext.Students.Remove(student);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return dataBaseContext.Students.Where(predicate).ToList();
        }

        public IEnumerable<Student> GetAll()
        {
            return dataBaseContext.Students;
        }

        public Student GetRecord(int recordId)
        {
            return dataBaseContext.Students.FirstOrDefault(s=>s.StudentId== recordId);
        }

        public void Update(Student item)
        {
            dataBaseContext.Entry(item).State = EntityState.Modified;
        }
    }
}
