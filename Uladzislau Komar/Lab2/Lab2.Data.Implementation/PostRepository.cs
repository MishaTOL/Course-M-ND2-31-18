using Lab2.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab2.Data.Implementation
{
    public class PostRepository
    {
        public void Create(PostEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Posts.Add(entity);
                database.SaveChanges();
            }
        }
        public PostEntity Read(int id)
        {
            using (var database = new DBLab2Context())
            {
                return database.Posts.Find(id);
            }
        }
        public List<PostEntity> Read()
        {
            using (var database = new DBLab2Context())
            {
                return database.Set<PostEntity>().ToList();
            }
        }
        public void Update(PostEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Posts.Attach(entity);
                var entry = database.Entry(entity);
                entry.Property(e => e.Content).IsModified = true;
                database.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var database = new DBLab2Context())
            {
                var oldEntity = new PostEntity { PostId = id };
                database.Posts.Attach(oldEntity);
                database.Posts.Remove(oldEntity);
                database.SaveChanges();
            }
        }
        public void Delete(PostEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Posts.Attach(entity);
                database.Posts.Remove(entity);
                database.SaveChanges();
            }
        }
    }
}
