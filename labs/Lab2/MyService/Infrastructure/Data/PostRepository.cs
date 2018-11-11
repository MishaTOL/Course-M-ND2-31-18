using Lab2.MyService.Domain.Core;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            db.Posts.Add(item);
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
            return db.Posts.Find(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return db.Posts.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Post item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}