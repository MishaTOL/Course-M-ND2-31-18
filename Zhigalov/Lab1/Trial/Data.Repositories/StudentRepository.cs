using Data.Contracts.Entities;
using Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private JsonContext context;

        public StudentRepository()
        {
            context = new JsonContext();
        }

        public void Add(Student student)
        {
            var studentList = GetAll().ToList();
            student.Id = studentList.Count() > 0 ? studentList.Max(x => x.Id) + 1 : 1;
            studentList.Add(student);
            context.WriteDataBase(studentList);
        }

        public void Delete(int id)
        {
            var studentList = GetAll().ToList();
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].Id == id)
                {
                    studentList.Remove(studentList[i]);
                }
            }
            context.WriteDataBase(studentList);
        }

        public IEnumerable<Student> GetAll()
        {
            return context.ReadDataBase();
        }

        public Student GetById(int id)
        {
            var studentList = GetAll().ToList();
            return studentList.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Student student)
        {
            var studentList = GetAll().ToList();
            for (int i = 0; i < studentList.Count; i++)
            {
                if (studentList[i].Id == student.Id)
                {
                    studentList[i] = student;
                }
            }
            context.WriteDataBase(studentList);
        }
    }
}
