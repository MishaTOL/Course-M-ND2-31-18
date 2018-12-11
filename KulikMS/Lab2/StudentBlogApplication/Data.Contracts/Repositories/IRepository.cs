using Data.Contracts.Models;
using System.Collections.Generic;

namespace Data.Contracts.Repositories
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
