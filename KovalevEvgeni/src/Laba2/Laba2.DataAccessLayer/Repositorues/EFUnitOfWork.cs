using Laba2.DataAccessLayer.EF;
using Laba2.DataAccessLayer.Entity;
using Laba2.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.DataAccessLayer.Repositorues
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StudentDbContext dataBaseContext;
        private IRepository<Student> students;
        public IRepository<Student> Students
        {
            get
            {
                if (students == null)
                    students = new StudentRepositories(dataBaseContext);
                return students;
            }
        }
        private IRepository<Post> posts;
        public IRepository<Post> Posts
        {
            get
            {
                if (posts == null)
                    posts = new PostRepository(dataBaseContext);
                return posts;
            }
        }
        private IRepository<Tag> tags;
        public IRepository<Tag> Tags
        {
            get
            {
                if (tags == null)
                    tags = new TagRepository(dataBaseContext);
                return tags;
            }
        }
        private IRepository<Comment> comments;
        public IRepository<Comment> Comments
        {
            get
            {
                if (comments == null)
                    comments = new CommentRepository(dataBaseContext);
                return comments;
            }
        }

        public EFUnitOfWork()
        {
            dataBaseContext = new StudentDbContext();
        }

        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dataBaseContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            dataBaseContext.SaveChanges();
        }
    }
}
