using Contracts.Entity;
using Contracts.Interfaces;

namespace Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connectionString;
        private StudentRepository studentRepository;

        public UnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public IRepository<Student> Students
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new StudentRepository(connectionString);
                }
                return studentRepository;
            }
        }
    }
}
