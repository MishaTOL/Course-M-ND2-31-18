using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DBModels.Models;
using DBRepConUow.Context;

namespace DBRepConUow.Repositarys
{
    public class CommentRepositary : IRepositary<int, Comment>
    {
        private ForumContext db;
        public CommentRepositary(ForumContext db)
        {
            this.db = db;
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments.ToList();
        }

        public void Add(Comment Model)
        {
            db.Comments.Add(Model);
        }

        public void Delete(Comment Model)
        {
            db.Comments.Remove(Model);
        }

        public Comment Get(int Id)
        {
            return db.Comments.Find(Id);
        }

        public void Update(Comment Model)
        {
            db.Entry(Model).State = EntityState.Modified;
        }

        public void DeleteById(int Id)
        {
            db.Comments.Remove(
                db.Comments.Where(p => p.CommentId == Id).FirstOrDefault());
        }


    }
}