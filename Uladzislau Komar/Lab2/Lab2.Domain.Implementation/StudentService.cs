using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Lab2.Data.Contracts;
using Lab2.Data.Implementation;
using Lab2.Domain.Contracts;

namespace Lab2.Domain.Implementation
{
    public class StudentService
    {
        private StudentRepository repository;

        public StudentService()
        {
            repository = new StudentRepository();
        }

        public StudentViewModel AuthorizeStudent(StudentViewModel student)
        {
            StudentViewModel output;
            var model = Mapper.Map<StudentViewModel, StudentEntity>(student);
            var repositoryStudent = repository.Read(model);
            if (repositoryStudent == null)
            {
                repository.Create(model);
                repositoryStudent = repository.Read(model);
                output = Mapper.Map<StudentEntity, StudentViewModel>(repositoryStudent);
                return output;
            }
            else
            {
                output = Mapper.Map<StudentEntity, StudentViewModel>(repositoryStudent);
                return output;
            }
        }
    }
}
