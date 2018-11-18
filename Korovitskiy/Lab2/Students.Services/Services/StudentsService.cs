using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using Students.ServicesModel;
using System.Linq;
using Students.RepositoryModel;

namespace Students.Services.Services
{
    public class StudentsService : AbstractService<StudentInfo, Student>//IStudentsService
    {
        //private IEntityRepository<Student> _studentRepository = new EntityFrameworkRepository.StudentRepository();
        public StudentsService()
            : base(new EntityFrameworkRepository.StudentRepository())
        {

        }
        /*
        public void Create(StudentInfo student)
        {
            var dbStudentModel = AutoMapper.Mapper.Map<StudentInfo, RepositoryModel.Student>(student);
            _studentRepository.Create(dbStudentModel);
        }

        public IEnumerable<StudentInfo> GetStudents()
        {
            var repositoryResponse = _studentRepository.GetModelCollections();
            return AutoMapper.Mapper.Map<IEnumerable<RepositoryModel.Student>, IEnumerable<StudentInfo>>(repositoryResponse);
        }

        public StudentInfo GetStudentById(int id)
        {
            var dbStudentModel = _studentRepository.GetModelById(id);
            return AutoMapper.Mapper.Map<RepositoryModel.Student, StudentInfo>(dbStudentModel);
        }

        public void Update(StudentInfo student)
        {
            var dbStudentModel = AutoMapper.Mapper.Map<StudentInfo, RepositoryModel.Student>(student);
            _studentRepository.Update(dbStudentModel);
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }*/
    }
}
