using Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts.Repositories
{
    public interface IStudentRepository : IRepository
    {
        void Add(Student student);
        void Delete(int id);
        void Update(Student student);
        Student GetById(int id);
        IEnumerable<Student> GetAll();
    }
}
