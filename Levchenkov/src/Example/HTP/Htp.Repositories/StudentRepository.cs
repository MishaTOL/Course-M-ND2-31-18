using Htp.Data.Contracts.Repositories;
using System;

namespace Htp.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public string GetString()
        {
            return Guid.NewGuid().ToString();
        }
    }

    public class StudentRepository2 : IStudentRepository
    {
        public string GetString()
        {
            return DateTime.Now.ToString();
        }
    }
}
