using System.Collections.Generic;

namespace Student.Service
{
    public interface IStudentService
    {
        void Create(StudentViewModel student);
        void Delete(int id);
        List<StudentViewModel> GetList();
        StudentViewModel GetStudentById(int id);
        void Update(int id, StudentViewModel student);
    }
}