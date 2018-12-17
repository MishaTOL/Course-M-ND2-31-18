using System.Collections.Generic;

namespace Lab1.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        void Create(Student student);
        void Delete(int id);
        void Update(Student student);
    }
}
