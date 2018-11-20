using Lab2.DataAccess.Abstraction;
using Labs2.DataAccess.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace Lab2.DataAccess.Context
{
    public class EFContext : DbContext, IContext
    {
        public EFContext() : base("name=StudentPortalConnectionString")
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Student> Students { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public IQueryable<Comment> CommentsRepository => this.Comments;

        public IQueryable<Post> PostsRepository => this.Posts;

        public IQueryable<Student> StudentsRepository => this.Students;

        public IQueryable<Tag> TagsRepository => this.Tags;

        public void Save()
        {
            try
            {
                this.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                var h = e;
                Console.Write(e);
            }
        }

        public void Add<TEntity>(IQueryable<TEntity> repository, TEntity entity)
            where TEntity : class
        {
            (repository as DbSet<TEntity>).Add(entity);
        }

        public void Delete<TEntity>(IQueryable<TEntity> repository, TEntity entity)
            where TEntity : class
        {
            (repository as DbSet<TEntity>).Remove(entity);
        } 

        
    }
}
