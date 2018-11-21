using AutoMapper;
using Laba2.BusinessLogicLayer.DataTransferObject;
using Laba2.BusinessLogicLayer.Interfaces;
using Laba2.DataAccessLayer.Entity;
using Laba2.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.BusinessLogicLayer.Services
{
    public class ServiceStudent : IServiceStudent
    {
        private IUnitOfWork database { get; set; }

        public ServiceStudent(IUnitOfWork database)
        {
            this.database = database;
        }

        public StudentDTO GetStudent(string LastName, string FirstName)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            Student record = database.Students.Find(x => x.FirstName == FirstName && x.LastName == LastName).FirstOrDefault();
            if (record == null)
            {
                database.Students.Create(new Student { FirstName = FirstName, LastName = LastName });
                database.Save();
                record = database.Students.Find(x => x.FirstName == FirstName && x.LastName == LastName).FirstOrDefault();
            }
            return mapper.Map<Student, StudentDTO>(record);
        }

        public IEnumerable<StudentDTO> GetStudentes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(database.Students.GetAll());
        }

        public StudentDTO GetStudent(int studentId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentDTO>()).CreateMapper();
            return mapper.Map<Student, StudentDTO>(database.Students.GetRecord(studentId));
        }
    }
}
