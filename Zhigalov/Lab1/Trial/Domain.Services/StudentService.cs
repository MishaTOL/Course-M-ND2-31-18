using Data.Repositories;
using Domain.Contracts.Services;
using Domain.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contracts.Entities;

namespace Domain.Services
{
    public class StudentService : IStudentService
    {
        private StudentRepository repository;

        public StudentService()
        {
            repository = new StudentRepository();
        }

        public void Add(StudentViewModel student)
        {
            var studentEntity = Mapper.Map<Student>(student);
            repository.Add(studentEntity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            var studentListEntity = repository.GetAll();
            var studentList = Mapper.Map<IEnumerable<StudentViewModel>>(studentListEntity);
            return studentList;
        }

        public StudentViewModel GetById(int id)
        {
            var studentEntity = repository.GetById(id);
            var student = Mapper.Map<StudentViewModel>(studentEntity);
            return student;
        }

        public void Update(StudentViewModel student)
        {
            var studentEntity = Mapper.Map<Student>(student);
            repository.Update(studentEntity);
        }
    }
}
