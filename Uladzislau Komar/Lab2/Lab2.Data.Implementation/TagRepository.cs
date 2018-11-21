using Lab2.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Data.Implementation
{
    public class TagRepository
    {
        public void Create(int postId, TagEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                var post = database.Posts.Find(postId);
                entity.Posts = new List<PostEntity>();
                entity.Posts.Add(post);

                database.Tags.Add(entity);

                database.SaveChanges();
            }
        }
        public TagEntity Read(int id)
        {
            using (var database = new DBLab2Context())
            {
                return database.Tags.Find(id);
            }
        }
        public List<TagEntity> Read()
        {
            using (var database = new DBLab2Context())
            {
                return database.Set<TagEntity>().ToList();
            }
        }
        public void Update(TagEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Tags.Attach(entity);
                var entry = database.Entry(entity);
                entry.Property(e => e.Name).IsModified = true;
                database.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var database = new DBLab2Context())
            {
                var oldEntity = new TagEntity { TagId = id };
                database.Tags.Attach(oldEntity);
                database.Tags.Remove(oldEntity);
                database.SaveChanges();
            }
        }
        public void Delete(TagEntity entity)
        {
            using (var database = new DBLab2Context())
            {
                database.Tags.Attach(entity);
                database.Tags.Remove(entity);
                database.SaveChanges();
            }
        }
    }
}
