using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Students.RepositoryModel;

namespace Students.Repository.Repository
{
    public class StudentsJsonRepository : IStudentRepository
    {
        private JavaScriptSerializer _jsonSerializer;
        private readonly string _pathToStudentsJsonFile = 
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "students.json");

        public StudentsJsonRepository()
        {
            _jsonSerializer = new JavaScriptSerializer();
        }

        public void Create(Student student)
        {
            var exististsStudents = GetStudents();
            var students = new List<Student>(exististsStudents);
            student.Id = exististsStudents.Count() > 0
                ? exististsStudents.Max(s => s.Id) + 1
                : 1;
            students.Add(student);
            SerializeStudentsCollection(students);
        }

        public Student GetStudentById(int id)
        {
            var students = GetStudents();
            return students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            if (!System.IO.File.Exists(_pathToStudentsJsonFile))
                return new List<Student>();
            string studentsCollectionJson = System.IO.File.ReadAllText(_pathToStudentsJsonFile);
            return _jsonSerializer.Deserialize<List<Student>>(studentsCollectionJson);
        }

        public void Update(Student student)
        {
            var students = GetStudents().ToList();
            for (int i = 0; i < students.Count(); i++)
            {
                if (students[i].Id != student.Id)
                    continue;

                students[i] = student;
                break;
            }

            SerializeStudentsCollection(students);
        }

        public void Delete(int id)
        {
            var students = GetStudents().ToList();
            for (int i = 0; i < students.Count(); i++)
            {
                if (students[i].Id != id)
                    continue;

                students.Remove(students[i]);
                break;
            }
            SerializeStudentsCollection(students);
        }

        #region private methods

        private void SerializeStudentsCollection(IEnumerable<Student> collections)
        {
            var jsonString = _jsonSerializer.Serialize(collections.OrderBy(s => s.Id));
            using (var writer = System.IO.File.CreateText(_pathToStudentsJsonFile))
            {
                writer.Write(jsonString);
                writer.Close();
            }
        }

        #endregion
    }
}
