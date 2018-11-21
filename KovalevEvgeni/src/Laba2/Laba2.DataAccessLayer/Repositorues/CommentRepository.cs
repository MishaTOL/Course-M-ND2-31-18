using Laba2.DataAccessLayer.EF;
using Laba2.DataAccessLayer.Entity;
using Laba2.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.DataAccessLayer.Repositorues
{
    public class CommentRepository : IRepository<Comment>
    {
        private StudentDbContext dataBaseContext;
        public CommentRepository(StudentDbContext dataBase)
        {
            dataBaseContext = dataBase;
        }

        public void Create(Comment item)
        {
            dataBaseContext.Comments.Add(item);
        }

        public void Delete(int recordId)
        {
            Comment record = GetRecord(recordId);
            if (record != null)
                dataBaseContext.Comments.Remove(record);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
           return dataBaseContext.Comments.Include("Student").Where(predicate).ToList();
        }

        public IEnumerable<Comment> GetAll()
        {
            return dataBaseContext.Comments;
        }

        public Comment GetRecord(int recordId)
        {
            return dataBaseContext.Comments.FirstOrDefault(s => s.CommentId == recordId);
        }

        public void Update(Comment item)
        {
             dataBaseContext.Entry(item).State = EntityState.Modified;
        }
    }
}
