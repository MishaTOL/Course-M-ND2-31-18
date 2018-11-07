using Repository.Context;
using Repository.Interfaces;
using RepositoryModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PostRepository : IPostRepository
    {
        StudPortalContext context;

        public PostRepository()
        {
            context = new StudPortalContext();
        }

        public void Create(PostEntity post)
        {
            post.Created = DateTime.Now;
            context.Posts.Add(post);
            context.SaveChanges();
        }

        public void Delete(int id)
        { 
            context.Posts.Remove(GetById(id));
            context.SaveChanges();
        }

        public IEnumerable<PostEntity> GetAll()
        {
            return context.Posts.Include("Author");
        }

        public PostEntity GetById(int id)
        {
            return context.Posts.FirstOrDefault(x => x.Id == id);
        }

        public void Update(PostEntity post)
        {
            context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
