using Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Services
{
    public interface IStudentService
    {
        void Add(StudentViewModel student);
        void Delete(int id);
        void Update(StudentViewModel student);
        StudentViewModel GetById(int id);
        IEnumerable<StudentViewModel> GetAll();
    }
}
