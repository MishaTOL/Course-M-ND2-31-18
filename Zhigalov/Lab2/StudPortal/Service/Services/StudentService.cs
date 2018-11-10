
using Repository.Repositories;
using RepositoryModels;
using Service.Interfaces;
using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        StudentRepository repository;

        public StudentService()
        {
            repository = new StudentRepository();
        }

        public void Create(StudentInfo student)
        {
            var studentEntity = AutoMapper.Mapper.Map<StudentEntity>(student);
            repository.Create(studentEntity);
        }

        public StudentInfo CreateAndGet(StudentInfo student)
        {
            var studentEntity = AutoMapper.Mapper.Map<StudentEntity>(student);
            studentEntity = repository.CreateAndGet(studentEntity);
            var studentInfo = AutoMapper.Mapper.Map<StudentInfo>(studentEntity);
            return studentInfo;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentInfo> GetAll()
        {
            var studentsEntity = repository.GetAll();
            var studentsInfo = AutoMapper.Mapper.Map<IEnumerable<StudentInfo>>(studentsEntity);
            return studentsInfo;
        }

        public StudentInfo GetById(int id)
        {
            var studentEntity = repository.GetById(id);
            var studentInfo = AutoMapper.Mapper.Map<StudentInfo>(studentEntity);
            return studentInfo;
        }
    }
}
