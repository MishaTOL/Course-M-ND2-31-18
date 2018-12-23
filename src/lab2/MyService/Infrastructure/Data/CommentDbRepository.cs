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
    public class CommentDbRepository : ICommentDbRepository<Commentdb>
    {
        DataContext db;

        public CommentDbRepository()
        {
            db = new DataContext();
        }
        public void Create(Commentdb item)
        {
            db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Commentdb comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
        }

        public Commentdb Get(int id)
        {
            return db.Comments.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Commentdb> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commentdb> GetAll(int PostId)
        {
            return db.Comments.Where(s => s.PostId == PostId);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Commentdb item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}