using Labs2.DataAccess.Entity;
using System;
using System.Linq;

namespace Lab2.DataAccess.Abstraction
{
    public interface IContext : IDisposable
    {
        IQueryable<Comment> CommentsRepository { get; }

        IQueryable<Post> PostsRepository { get; }

        IQueryable<Student> StudentsRepository { get; }

        IQueryable<Tag> TagsRepository { get; }

        void Save();

        void Add<TEntity>(IQueryable<TEntity> repository, TEntity entity)
            where TEntity : class;

        void Delete<TEntity>(IQueryable<TEntity> repository, TEntity entity)
            where TEntity : class;
    }
}
