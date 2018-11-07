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
    public class CommentRepository : ICommentRepository
    {
        StudPortalContext context;

        public CommentRepository()
        {
            context = new StudPortalContext();
        }

        public void Create(CommentEntity comment)
        {
            comment.Created = DateTime.Now;
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Comments.Remove(context.Comments.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

        public void Edit(CommentEntity comment)
        {
            context.Entry(comment).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<CommentEntity> GetAll()
        {
            return context.Comments;
        }
    }
}
