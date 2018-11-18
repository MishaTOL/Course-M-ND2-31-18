using Demo.Contracts;

namespace Demo.Services
{
    class StudentService : IStudentService
    {
        private readonly IStudentRepository repository;
        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }
    }
}
