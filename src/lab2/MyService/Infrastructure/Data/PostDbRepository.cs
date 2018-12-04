using Lab2.Models.db;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Data
{
    public class PostDbRepository : IRepository<Postdb>
    {
        DataContext db;
        public PostDbRepository()
        {
            db = new DataContext();
        }

        public void Create(Postdb item)
        {
            db.Posts.Add(item);
        }

        public void Delete(int id)
        {
            Postdb post = db.Posts.Find(id);
            db.Posts.Remove(post);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Postdb Get(int id)
        {
            return db.Posts.Find(id);
        }

        public IEnumerable<Postdb> GetAll()
        {
            return db.Posts.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Postdb item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}