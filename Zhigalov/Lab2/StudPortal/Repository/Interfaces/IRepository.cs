using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T target);
        void Delete(int id);
        IEnumerable<T> GetAll();
    }
}
