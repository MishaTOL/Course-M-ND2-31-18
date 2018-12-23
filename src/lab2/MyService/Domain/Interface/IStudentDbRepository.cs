using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Domain.Interface
{
    public interface IStudentDbRepository<T> where T: class
    {

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(int PostId);
        T Get(int id);
        T Get(T student);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();


    }
}