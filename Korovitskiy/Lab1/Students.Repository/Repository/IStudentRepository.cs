using Students.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Repository.Repository
{
    public interface IStudentRepository
    {
        void Create(Student student);
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudents();
        void Update(Student student);
        void Delete(int id);
    }
}
