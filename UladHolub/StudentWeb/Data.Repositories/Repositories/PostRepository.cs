using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Contracts.Entities;
using Data.Contracts.Repositories;
using Data.Repositories.EntityFramework;

namespace Data.Repositories.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private StudentContext dataBase;

        public PostRepository(StudentContext context)
        {
            dataBase = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return dataBase.Posts;
        }

        public Post Get(int id)
        {
            return dataBase.Posts.Find(id);
        }

        public void Create(Post post)
        {
            dataBase.Posts.Add(post);
        }

        public void Update(Post post)
        {
            dataBase.Entry(post).State = EntityState.Modified;
        }

        public IEnumerable<Post> Find(Func<Post, Boolean> predicate)
        {
            return dataBase.Posts.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Post post = dataBase.Posts.Find(id);

            if (post != null) { dataBase.Posts.Remove(post); }
        }
    }
}
