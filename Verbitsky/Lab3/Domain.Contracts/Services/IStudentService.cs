using System;
using System.Collections.Generic;
using Data.Contracts.Entities;

namespace Domain.Contracts.Services
{
    public interface IStudentService
    {
        void Update(Student student);
        List<Student> Read();
        void Create(Student student);
        void Delete(int id);
    }
}