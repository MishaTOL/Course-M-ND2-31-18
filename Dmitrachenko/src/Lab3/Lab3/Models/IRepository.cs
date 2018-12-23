using System.Collections.Generic;

namespace Lab3.Models
{
    public interface IRepository
    {
        void Save(Student student);
        IEnumerable<Student> List();
        Student Get(int id);
    }
}