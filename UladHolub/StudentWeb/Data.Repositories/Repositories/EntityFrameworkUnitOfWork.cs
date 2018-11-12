using Data.Contracts.Entities;
using Data.Contracts.Repositories;
using Data.Repositories.EntityFramework;
using System;

namespace Data.Repositories.Repositories
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private StudentContext dataBase;
        private StudentRepository studentRepository;
        private PostRepository postRepository;
        private CommentRepository commentRepository;
        private TagRepository tagRepository;

        public EntityFrameworkUnitOfWork(string connectionString)
        {
            dataBase = new StudentContext(connectionString);
        }

        public IRepository<Student> Students
        {
            get
            {
                if (studentRepository == null) { studentRepository = new StudentRepository(dataBase); }

                return studentRepository;
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                if (postRepository == null) { postRepository = new PostRepository(dataBase); }

                return postRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null) { commentRepository = new CommentRepository(dataBase); }

                return commentRepository;
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (tagRepository == null) { tagRepository = new TagRepository(dataBase); }

                return tagRepository;
            }
        }

        public void Save()
        {
            dataBase.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataBase.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
