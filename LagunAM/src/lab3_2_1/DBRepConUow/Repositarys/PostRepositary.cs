using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DBModels.Models;
using DBRepConUow.Context;

namespace DBRepConUow.Repositarys
{
    public class PostRepositary : IRepositary<int, Post>
    {
        ForumContext db;
        public PostRepositary(ForumContext db)
        {
            this.db = db;
        }

        public IEnumerable<Post> GetAll()
        {
            return db.Posts.ToList();
        }

        public void Add(Post Model)
        {
            db.Posts.Add(Model);
        }

        public void Delete(Post Model)
        {
            db.Posts.Remove(Model);
        }

        public Post Get(int Id)
        {
            return db.Posts.Find(Id);
        }

        public void Update(Post Model)
        {
            db.Entry(Model).State = EntityState.Modified;
        }

        public void DeleteById(int postId)
        {
            db.Posts.Remove(
                db.Posts.Where(p => p.PostId == postId).FirstOrDefault());
        }

    }
}