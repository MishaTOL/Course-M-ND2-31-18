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
    public class PostRepository : IRepository<Post>
    {
        private StudentDbContext dataBaseContext;

        public PostRepository(StudentDbContext dataBase)
        {
            dataBaseContext = dataBase;
        }

        public void Create(Post item)
        {
            dataBaseContext.Posts.Add(item);
        }

        public void Delete(int recordId)
        {
            Post record = GetRecord(recordId);
            if (record != null)
                dataBaseContext.Posts.Remove(record);
        }

        public IEnumerable<Post> Find(Func<Post, bool> predicate)
        {
            return dataBaseContext.Posts.Include("Student").Include("Tag").Where(predicate).ToList();
        }

        public IEnumerable<Post> GetAll()
        {
            return dataBaseContext.Posts.Include("Student").ToList();
        }

        public Post GetRecord(int recordId)
        {
            return dataBaseContext.Posts.Include("Student").FirstOrDefault(s => s.PostId == recordId);
        }

        public void Update(Post item)
        {
            foreach(var tag in item.Tags)
            {
                dataBaseContext.Entry(tag).State = EntityState.Modified;
            }
            dataBaseContext.Entry(item).State = EntityState.Modified;
        }
    }
}
