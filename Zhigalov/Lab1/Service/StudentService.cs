
using Lab1.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab1.Service
{
    public class StudentService
    {
        List<Student> studentList;
        Student studentForDelete;
        string connectionString;
        public List<Student> StudentList => studentList;

        public StudentService()
        {
            studentForDelete = new Student();
            connectionString = @"D:\IT Academy\Lab1\Lab1\App_Data\StudentDataBase.txt";     // it should be in Web.config
        }

        public void AddNewStudent(Student student)
        {
            InitializeDataBase();
            student.Id = studentList.Count + 1;
            studentList.Add(student);
            WriteToDataBase(studentList);
        }

        public void ChangeStudent(Student newStudent)
        {
            InitializeDataBase();
            foreach (Student student in studentList)
            {
                if (student.Id == newStudent.Id)
                {
                    student.FirstName = newStudent.FirstName;
                    student.LastName = newStudent.LastName;
                }
            }
            WriteToDataBase(studentList);
        }

        public void DeleteById(int id)
        {
            InitializeDataBase();
            if (studentList.Count != 0)
            {
                studentList.RemoveAt(--id);
                UpdateId(studentList);
                WriteToDataBase(studentList);
            }
        }

        public Student FindById(int id)
        {
            InitializeDataBase();

            foreach (Student student in studentList)
            {
                if (student.Id == id)
                {
                    studentForDelete = student;
                }
            }

            return studentForDelete;
        }

        public void UpdateId(List<Student> studentList)
        {
            int newId = 1;
            foreach (Student student in studentList)
            {
                student.Id = newId;
                newId++;
            }
        }

        public void InitializeDataBase()
        {
            studentList = ReadDataBase();

            if (studentList == null)
            {
                studentList = new List<Student>();
            }
        }

        private List<Student> ReadDataBase()
        {
            string json = File.ReadAllText(connectionString);
            studentList = JsonConvert.DeserializeObject<List<Student>>(json);
            return studentList;
        }

        private void WriteToDataBase(List<Student> studentList)
        {
            string json = JsonConvert.SerializeObject(studentList, Formatting.Indented);
            File.WriteAllText(connectionString, json);
        }
    }
}