using RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStudentRepository : IRepository<StudentEntity>
    {
        void Edit(StudentEntity student);
        StudentEntity GetById(int id);
        StudentEntity CreateAndGet(StudentEntity student);
    }
}
