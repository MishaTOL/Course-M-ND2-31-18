using Htp.Data.Contracts.Repositories;
using Htp.Domain.Contracts.Services;
using System;

namespace Htp.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public string GetString()
        {
            return studentRepository.GetString();
        }
    }
}
