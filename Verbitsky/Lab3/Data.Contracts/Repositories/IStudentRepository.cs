using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Contracts.Entities;

namespace Data.Contracts.Repositories
{
    public interface IStudentRepository : IRepository
    {
        void Update(Student student);
        List<Student> Read();
        void Create(Student student);
        void Delete(int id);
    }
}
