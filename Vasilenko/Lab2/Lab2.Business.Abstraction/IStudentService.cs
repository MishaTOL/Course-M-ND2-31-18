using Lab2.Business.Abstraction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Business.Abstraction
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        int AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        Student GetByCredits(string name, string lastName);
        bool FindStudent(string name, string lastName);
    }
}
