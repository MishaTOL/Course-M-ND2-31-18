using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DBModels.Models;
using DBRepConUow.Repositarys;
using DBRepConUow.UnitOfWork;
using Lab2_Lab1.InfoModels;

namespace Lab2_Lab1.Services
{
    public class StudentService:IService<Student>
    {
        private IForumUOW forumUOW;
        private Student MapStudentInfoToStudent(StudentInfo studentInfo)
        {
            return Mapper.Map<StudentInfo, Student>(studentInfo); 
        }
        private StudentInfo MapStudentToStudentInfo(Student student)
        {
            return Mapper.Map<Student, StudentInfo>(student);
        }

        public StudentService(IForumUOW forumUOW)
        {
            this.forumUOW = forumUOW;
        }
        public bool CheckEmail(string Email)
        {
            return (((StudentRepositary)(forumUOW.StudentRepositary))
                .GetByEmail(Email) == null) ? true : false;
        }
        public bool CheckNickName(string NickName)
        {
            return (((StudentRepositary)(forumUOW.StudentRepositary))
                .GetByNickName(NickName) == null) ? true : false;
        }
        public void Add(StudentInfo studentInfo)
        {
            forumUOW.StudentRepositary.Add(
                MapStudentInfoToStudent(studentInfo));
            forumUOW.Save();  
        }
        public void Edit(StudentInfo studentInfo)
        {
            Student student = MapStudentInfoToStudent(studentInfo);
            student = forumUOW.StudentRepositary.Get(student.StudentId);
            student.FirstName = studentInfo.FirstName;
            student.Pass = studentInfo.Pass;
            forumUOW.StudentRepositary.Update(
                student);
            forumUOW.Save();
        }
        public void Remove(StudentInfo studentInfo)
        {
            forumUOW.StudentRepositary.Delete(
                MapStudentInfoToStudent(studentInfo));
            forumUOW.Save();
        }
        public StudentInfo Get(int StudentId)
        {
            return MapStudentToStudentInfo(
                forumUOW.StudentRepositary.Get(StudentId));      
        }
        public StudentInfo Autentification(StudentInfo studentInfo)
        {
            return 
                MapStudentToStudentInfo(
                ((StudentRepositary)(forumUOW.StudentRepositary)).Autentification(
                MapStudentInfoToStudent(studentInfo)));
        }
       
    }
}