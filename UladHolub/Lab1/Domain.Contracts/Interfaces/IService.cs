using Domain.Contracts.Entity;
using System.Collections.Generic;

namespace Domain.Contracts.Interfaces
{
    public interface IService
    {
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel Get(int id);
        bool Create(StudentViewModel item);
        bool Update(StudentViewModel item);
        bool Delete(int id);
    }
}
