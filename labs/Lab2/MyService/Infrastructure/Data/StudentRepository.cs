using Lab2.MyService.Domain.Core;
using Lab2.MyService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Data
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student item)
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

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Student item)
        {
            throw new NotImplementedException();
        }
    }
}