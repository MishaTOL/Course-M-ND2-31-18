using Students.ServicesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Services.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetStudents();
        void Create(Student student);
        Student GetStudentById(int id);
        void Update(Student student);
        void Delete(int id);
    }
}
