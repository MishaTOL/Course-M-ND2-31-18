using Student.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Service
{
    public class StudentService : IStudentService
    {
        private IStudentRepository repository;

        public StudentService()
        {
            repository = new StudentRepository();
        }

        public void Create(StudentViewModel student)
        {
            repository.Students = repository.Load();
            repository.Students.Add(new Repository.StudentEntity
            {
                Id = repository.Students.Count,
                Name = student.Name,
                Surname = student.Surname,
                Course = student.Course
            });
            repository.Save();
        }

        public StudentViewModel GetStudentById(int id)
        {
            var selectedStudent = repository.Load().Where(x => x.Id == id);
            var student = selectedStudent.ToList()[0];
            return new StudentViewModel //я очень тороплюсь сдать эту лабу, прошу понять и простить
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Course = student.Course
            };
        }

        public void Update(int id, StudentViewModel student)
        {
            repository.Students = repository.Load();
            repository.Students[id] = new Repository.StudentEntity
            {
                Name = student.Name,
                Surname = student.Surname,
                Course = student.Course
            };
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Students = repository.Load();
            var student = repository.Students.Where(x => x.Id == id).ToList()[0];
            repository.Students.Remove(student);
            repository.Save();
        }

        public List<StudentViewModel> GetList()
        {
            var list = repository.Load();
            List<StudentViewModel> outputList = new List<StudentViewModel>();
            for (int i = 0; i < list.Count; i++)
            {
                outputList.Add(new StudentViewModel
                {
                    Id = list[i].Id,
                    Name = list[i].Name,
                    Surname = list[i].Surname,
                    Course = list[i].Course

                });
            }
            return outputList ?? new List<StudentViewModel>();
        }
    }
}