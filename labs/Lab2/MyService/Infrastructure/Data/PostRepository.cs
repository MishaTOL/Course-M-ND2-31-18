using Lab2.MyService.Domain.Core;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Data
{
    public class PostRepository : IRepository<Post>
    {
        DataContext db;

        public PostRepository()
        {
            db = new DataContext();
        }

        public void Create(Post item)
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

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return db.Posts.ToList();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Post item)
        {
            throw new NotImplementedException();
        }
    }
}