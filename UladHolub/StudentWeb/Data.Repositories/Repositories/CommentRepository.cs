using Data.Contracts.Entities;
using Data.Contracts.Repositories;
using Data.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private StudentContext dataBase;

        public CommentRepository(StudentContext context)
        {
            dataBase = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return dataBase.Comments;
        }

        public Comment Get(int id)
        {
            return dataBase.Comments.Find(id);
        }

        public void Create(Comment comment)
        {
            dataBase.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            dataBase.Entry(comment).State = EntityState.Modified;
        }

        public IEnumerable<Comment> Find(Func<Comment, Boolean> predicate)
        {
            return dataBase.Comments.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Comment comment = dataBase.Comments.Find(id);

            if (comment != null) { dataBase.Comments.Remove(comment); }
        }
    }
}
