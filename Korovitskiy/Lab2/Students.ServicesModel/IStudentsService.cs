using System;
using System.Collections.Generic;
using System.Text;

namespace Students.ServicesModel
{
    public interface IStudentsService
    {
        IEnumerable<StudentInfo> GetStudents();
        void Create(StudentInfo student);
        StudentInfo GetStudentById(int id);
        void Update(StudentInfo student);
        void Delete(int id);
    }
}
