using Demo.Contracts;

namespace Demo.Repositories
{
    class StudentRepository : IStudentRepository
    {
        private readonly IContext context;
        public StudentRepository(IContext context)
        {
            this.context = context;
        }
    }
}
