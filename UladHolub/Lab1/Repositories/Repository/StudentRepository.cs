using Contracts.Entity;
using Contracts.Interfaces;
using Repositories.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private FileOperations fileOperations;

        public StudentRepository(string connectionString)
        {
            fileOperations = new FileOperations(connectionString);
        }

        public void Create(Student item)
        {
            var students = fileOperations.GetListFromFile().ToList();
            var id = GetMaxIdFromList(students)+1;
            item.Id = id;
            students.Add(item);
            fileOperations.SerializeJsonToFile(students);
        }

        public void Delete(int id)
        {
            var students = fileOperations.GetListFromFile().ToList();
            if (students == null) { return; }
            var found = students.Find(x => x.Id == id);
            if (found != null) { students.Remove(found); }
            fileOperations.SerializeJsonToFile(students);
        }

        public Student Get(int id)
        {
            var students = fileOperations.GetListFromFile().ToList();
            if (students == null) { return null; }
            return students.Find(x => x.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return fileOperations.GetListFromFile();
        }

        public void Update(Student item)
        {
            var students = fileOperations.GetListFromFile().ToList();
            if (students == null) { return; }
            var index = students.FindIndex(x => x.Id == item.Id);
            students[index] = item;
            fileOperations.SerializeJsonToFile(students);
        }

        private int GetMaxIdFromList(IEnumerable<Student> list)
        {
            if (list == null) return 0;
            int maxId = 0;
            foreach (var elem in list)
            {
                if (elem.Id > maxId) { maxId = elem.Id; }
            }
            return maxId;
        }
    }
}
