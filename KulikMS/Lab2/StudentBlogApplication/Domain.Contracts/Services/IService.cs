using System.Collections.Generic;

namespace Domain.Contracts.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entityView);
        void Delete(int id);
        void Update(T entityView);
    }
}
