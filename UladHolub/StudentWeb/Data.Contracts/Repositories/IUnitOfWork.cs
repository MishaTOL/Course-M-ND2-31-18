using Data.Contracts.Entities;
using System;

namespace Data.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<Post> Posts { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Tag> Tags { get; }
        void Save();
    }
}
