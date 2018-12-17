using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace Lab1.Models
{
    public class StudentJsonRepository : IStudentRepository
    {
        private readonly string _filePath;
        private ICollection<Student> _students;
        public StudentJsonRepository()
        {
            _filePath = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["PathToStudentsJson"]);
            _students = LoadStudents();
        }
        public void Create(Student student)
        {
            student.Id = _students.Count == 0 ? 0 : _students.Max(s => s.Id) + 1;
            _students.Add(student);
            SaveStudents();
        }

        public void Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return;
            }

            _students.Remove(student);
            SaveStudents();
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public void Update(Student student)
        {
            var oldStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (oldStudent == null)
            {
                return;
            }

            oldStudent.FirstName = student.FirstName;
            oldStudent.LastName = student.LastName;
            SaveStudents();
        }

        private ICollection<Student> LoadStudents()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Student>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<ICollection<Student>>(json);
        }
        private void SaveStudents()
        {
            var json = JsonConvert.SerializeObject(_students);
            File.WriteAllText(_filePath, json);
        }
    }
}