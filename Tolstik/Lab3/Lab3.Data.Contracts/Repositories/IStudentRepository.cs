using Lab3.Data.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Data.Contracts.Repositories
{
    public interface IStudentRepository : IRepository
    {
        Student FindStudent(int id);
        List<Student> FindAllStudents();
    }
}
