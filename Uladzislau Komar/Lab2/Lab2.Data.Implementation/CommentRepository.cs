using Lab2.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Data.Implementation
{
    public class CommentRepository
    {
        public void Create(CommentEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Comments.Add(entity);
                database.SaveChanges();
            }
        }
        public CommentEntity Read(int id)
        {
            using (var database = new DBLab2Context())
            {
                return database.Comments.Find(id);
            }
        }
        public List<CommentEntity> Read()
        {
            using (var database = new DBLab2Context())
            {
                return database.Set<CommentEntity>().ToList();
            }
        }
        public void Update(CommentEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Comments.Attach(entity);
                var entry = database.Entry(entity);
                entry.Property(e => e.Content).IsModified = true;
                database.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var database = new DBLab2Context())
            {
                var oldEntity = new CommentEntity { CommentId = id };
                database.Comments.Attach(oldEntity);
                database.Comments.Remove(oldEntity);
                database.SaveChanges();
            }
        }
        public void Delete(CommentEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Comments.Attach(entity);
                database.Comments.Remove(entity);
                database.SaveChanges();
            }
        }
    }
}
