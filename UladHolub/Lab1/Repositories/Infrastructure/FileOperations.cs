using Contracts.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Infrastructure
{
    internal class FileOperations
    {
        private string fileName;

        public FileOperations(string connectionString)
        {
            fileName = connectionString;
            if (!File.Exists(fileName)) { File.Create(fileName); }
        }

        public IEnumerable<Student> GetListFromFile()
        {
            CheckExist(fileName);
            IEnumerable<Student> returnList = null;
            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                returnList = (IEnumerable<Student>)serializer.Deserialize(file, typeof(IEnumerable<Student>));
            }
            if (returnList == null) return new List<Student>();
            return returnList;
        }

        public void SerializeJsonToFile(IEnumerable<Student> list)
        {
            CheckExist(fileName);
            using (StreamWriter file = File.CreateText(fileName))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, list);
            }
        }

        private void CheckExist(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(String.Format("Json file \"{0}\" not found!", fileName));
            }
        }
    }
}
