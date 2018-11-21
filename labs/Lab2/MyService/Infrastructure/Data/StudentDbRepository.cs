using Lab2.Models.db;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Data
{
    public class StudentDbRepository : IRepository<Studentdb>
    {
        DataContext db;

        public StudentDbRepository()
        {
            db = new DataContext();
        }
        public void Create(Studentdb item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Studentdb Get(int id)
        {
            return db.Students.Find(id);
        }

        public IEnumerable<Studentdb> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Studentdb item)
        {
            throw new NotImplementedException();
        }
    }
}