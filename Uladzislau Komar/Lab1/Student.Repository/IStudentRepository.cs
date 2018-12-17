using System.Collections.Generic;

namespace Student.Repository
{
    public interface IStudentRepository
    {
        List<StudentEntity> Students { get; set; }

        List<StudentEntity> Load();
        void Save();
    }
}