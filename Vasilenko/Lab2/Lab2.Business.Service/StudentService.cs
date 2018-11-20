using Lab2.Business.Abstraction;
using Lab2.Business.Abstraction.Entity;
using Lab2.DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentContract = Labs2.DataAccess.Entity.Student;

namespace Lab2.Business.Service
{
    public class StudentService : IStudentService
    {
        private readonly IContextFactory contextFactory;

        public StudentService(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public int AddStudent(Student student)
        {
            using (var context = this.contextFactory.GetContext())
            {
                context.Add(context.StudentsRepository, new StudentContract()
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                });
                context.Save();
                var find = context.StudentsRepository
                    .Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).FirstOrDefault();
                return find.Id;            
            }
        }

        public void DeleteStudent(int id)
        {
            using (var context = this.contextFactory.GetContext())
            {
                var student = context.StudentsRepository.FirstOrDefault(m => m.Id == id);

                if (student != null)
                {
                    context.Delete(context.StudentsRepository, student);
                    context.Save();
                }
            }
        }

        public Student GetByCredits(string name, string lastName)
        {
            using (var context = this.contextFactory.GetContext())
            {
                return context.StudentsRepository
                    .Where(x=> x.FirstName.Equals(name, StringComparison.CurrentCultureIgnoreCase) && x.LastName.Equals(lastName, StringComparison.CurrentCultureIgnoreCase))
                    .Select(x => new Student() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName })
                    .FirstOrDefault();
            }
        }

        public List<Student> GetStudents()
        {
            using (var context = this.contextFactory.GetContext())
            {
                return context.StudentsRepository
                    .Select(x => new Student() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName })
                    .ToList();
            }
        }

        public void UpdateStudent(Student model)
        {
            using (var context = this.contextFactory.GetContext())
            {
                var student = context.StudentsRepository.FirstOrDefault(m => m.Id == model.Id);

                if (student != null)
                {
                    student.LastName = model.LastName;
                    student.FirstName = model.FirstName;
                    context.Save();
                }
            }
        }

        public bool FindStudent(string name, string lastName)
        {
            using (var context = this.contextFactory.GetContext())
            {
                var find = context.StudentsRepository.Where( x => x.FirstName == name&& x.LastName ==lastName );

                if (find != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
