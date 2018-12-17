using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using Students.ServicesModel;
using System.Linq;
using Students.Repository.Repository;

namespace Students.Services.Services
{
    public class StudentsService : IStudentsService
    {
        IStudentRepository _studentRepository;
        public StudentsService()
        {
            _studentRepository = new StudentsJsonRepository();
        }

        public void Create(Student student)
        {
            ValidateStudent(student);
            var dbStudentModel = AutoMapper.Mapper.Map<Student,RepositoryModel.Student>(student);
            _studentRepository.Create(dbStudentModel);
        }

        public IEnumerable<Student> GetStudents()
        {
            var repositoryResponse =_studentRepository.GetStudents();
            return AutoMapper.Mapper.Map<IEnumerable<RepositoryModel.Student>, IEnumerable<Student>>(repositoryResponse);
        }

        public Student GetStudentById(int id)
        {
            var dbStudentModel =_studentRepository.GetStudentById(id);
            return AutoMapper.Mapper.Map<RepositoryModel.Student, Student>(dbStudentModel);
        }

        public void Update(Student student)
        {
            ValidateStudent(student);
            var dbStudentModel = AutoMapper.Mapper.Map<Student, RepositoryModel.Student>(student);
            _studentRepository.Update(dbStudentModel);
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }

        #region private methods

        private void ValidateStudent(Student student)
        {
            if (student.Course > 5 || student.Course < 1)
                throw new IndexOutOfRangeException("Courses value out of range");
        }

        #endregion
    }
}
