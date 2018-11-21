using System;
using System.Collections.Generic;
using System.Text;

namespace Students.RepositoryModel
{
    public interface IEntityRepository<T>
    {
        void Create(T student);
        T GetModelById(int id);
        IEnumerable<T> GetModelCollections();
        void Update(T student);
        void Delete(int id);
    }
}
