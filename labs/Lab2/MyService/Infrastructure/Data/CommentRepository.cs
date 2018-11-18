using Lab2.Models;

using Lab2.MyService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Data
{
    public class CommentRepository : IRepository<Comment>
    {
        public void Create(Comment item)
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

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Comment item)
        {
            throw new NotImplementedException();
        }
    }
}