using System.Collections.Generic;
using System.IO;
using Contracts.Entity;
using Contracts.Interfaces;
using Data.Services.Infrastructure;
using Domain.Contracts.Entity;
using Domain.Contracts.Interfaces;

namespace Data.Services.Services
{
    public class StudentService: IService
    {
        private IUnitOfWork database { get; set; }

        public StudentService(IUnitOfWork iUnitOfWork)
        {
            database = iUnitOfWork;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            IEnumerable<Student> students = null;
            try { students = database.Students.GetAll(); }
            catch (FileNotFoundException) { return null; }
            var studentsViewModel = DomainMapper.Mapper.Map< IEnumerable<Student>, IEnumerable<StudentViewModel>>(students);
            return studentsViewModel;
        }

        public StudentViewModel Get(int id)
        {
            Student student = null;
            try { student = database.Students.Get(id); }
            catch (FileNotFoundException) { return null; }
            var studentViewModel = DomainMapper.Mapper.Map<Student, StudentViewModel>(student);
            return studentViewModel;
        }

        public bool Create(StudentViewModel item)
        {
            var student = DomainMapper.Mapper.Map<StudentViewModel, Student>(item);
            try { database.Students.Create(student); }
            catch (FileNotFoundException) { return false; }
            return true;
        }

        public bool Update(StudentViewModel item)
        {
            var student = DomainMapper.Mapper.Map<StudentViewModel, Student>(item);
            try { database.Students.Update(student); }
            catch (FileNotFoundException) { return false; }
            return true;
        }

        public bool Delete(int id)
        {
            try { database.Students.Delete(id); }
            catch (FileNotFoundException) { return false; }
            return true;
        }
    }
}
