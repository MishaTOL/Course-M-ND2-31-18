using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;

namespace Laba1.Models
{
    public class StudentRepository
    {
        #region Переменые
        private readonly string dataBasePath;
        #endregion

        #region Конструктор
        public StudentRepository()
        {
            dataBasePath = $"{HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data")}\\student.json";
        }
        #endregion

        #region Методы
        public IEnumerable<Student> Get()
        {
            Student[] result;
            DataContractJsonSerializer jsonFormated = new DataContractJsonSerializer(typeof(Student[]));
            FileInfo fileInfo = new FileInfo(dataBasePath);
            if (!fileInfo.Exists || fileInfo.Length == 0) return null;
            using (FileStream fs = new FileStream(dataBasePath, FileMode.OpenOrCreate))
            {
                result = (Student[])jsonFormated.ReadObject(fs);
            }
            return result;
        }

        public Student Initialize()
        {
            return new Student();
        }

        public void Add(Student value)
        {
            List<Student> record = Get()?.ToList() ?? new List<Student>();
            int maxId = record.Count() == 0 ? 0 : record.Max(s => s.StudentId);
            value.StudentId = maxId + 1;
            record.Add(value);
            SaveJson(record);
        }

        private void SaveJson(List<Student> record)
        {
            DataContractJsonSerializer jsonFormated = new DataContractJsonSerializer(typeof(Student[]));
            using (FileStream fs = new FileStream(dataBasePath, FileMode.Create))
            {
                jsonFormated.WriteObject(fs, record.ToArray());
            }
        }

        public void Remove(int studentId)
        {
            List<Student> record = Get()?.ToList() ?? new List<Student>();
            Student recordRemove = record.FirstOrDefault(s => s.StudentId == studentId);
            if (recordRemove == null) return;
            record.Remove(recordRemove);
            SaveJson(record);
        }

        public void Edit(Student student)
        {
            List<Student> record = Get()?.ToList() ?? new List<Student>();
            Student recordUpdate = record.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (recordUpdate == null) return;
            recordUpdate.Age = student.Age;
            recordUpdate.CourseName = student.CourseName;
            recordUpdate.FirstName = student.FirstName;
            recordUpdate.LastName = student.LastName;
            SaveJson(record);
        }
        #endregion
    }
}