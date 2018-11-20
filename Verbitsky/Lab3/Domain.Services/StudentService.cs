using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Services;
using Data.Contracts.Repositories;
using Data.Contracts.Entities;

namespace Domain.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public void Create(Student student)
        {
            studentRepository.Create(student);
        }
        public void Delete(int id)
        {
            studentRepository.Delete(id);
        }
        public List<Student> Read()
        {
            return studentRepository.Read();
        }
        public void Update(Student student)
        {
            studentRepository.Update(student);
        }
    }
}
