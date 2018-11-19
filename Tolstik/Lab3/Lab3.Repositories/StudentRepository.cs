using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Data.Contracts.Repositories;
using Lab3.Data.Contracts.Entities;

namespace Lab3.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Student FindStudent(int id)
        {
            return FindAllStudents().Where(s => s.Id == id).FirstOrDefault();
        }

        public List<Student> FindAllStudents()
        {
            var StudentList = new List<Student>();
            StudentList.Add(new Student() { Id = 1, FirstName = "John" , LastName = "Smith"});
            StudentList.Add(new Student() { Id = 2, FirstName = "Stan" , LastName = "Johns" });
            StudentList.Add(new Student() { Id = 3, FirstName = "Karina" , LastName = "Wild" });
            return StudentList;
        }
    }
}
