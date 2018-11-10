using Repository.Context;
using Repository.Interfaces;
using RepositoryModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        StudPortalContext context;

        public StudentRepository()
        {
            context = new StudPortalContext();
        }

        public void Create(StudentEntity student)
        {
            var queryResult = context.Students.Where(x => x.FirstName == student.FirstName
                                && x.LastName == student.LastName);
            if (queryResult.Count() == 0)
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public StudentEntity CreateAndGet(StudentEntity student)
        {
            StudentEntity currentStudent;

            var queryResult = context.Students.Where(x => x.FirstName == student.FirstName
                    && x.LastName == student.LastName);
            if (queryResult.Count() == 0)
            {
                context.Students.Add(student);
                context.SaveChanges();
                currentStudent = student;
            }

            else
            {
                currentStudent = queryResult.FirstOrDefault();
            }

            return currentStudent;
        }

        public void Delete(int id)
        {
            context.Students.Remove(context.Students.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public IEnumerable<StudentEntity> GetAll()
        {
            return context.Students;
        }

        public StudentEntity GetById(int id)
        {
            return context.Students.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(StudentEntity student)
        {
            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
