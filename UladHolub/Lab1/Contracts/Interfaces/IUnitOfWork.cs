using Contracts.Entity;

namespace Contracts.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }
    }
}
