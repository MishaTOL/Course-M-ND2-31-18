using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Student.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string path = AppContext.BaseDirectory + @"App_Data\Student.json";

        public StudentRepository()
        {
            Students = new List<StudentEntity>();
        }

        public List<StudentEntity> Students { get; set; }
        
        public List<StudentEntity> Load()
        {
            using (FileStream inputStream = File.Open(path, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(inputStream))
                {
                    string input = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<StudentEntity>>(input) ?? Students;
                }
            }
        }

        public void Save()
        {
            using (FileStream outputStream = File.OpenWrite(path))
            {
                using (StreamWriter writer = new StreamWriter(outputStream))
                {
                    string output = JsonConvert.SerializeObject(Students);
                    writer.WriteLine(output);
                }
            }
        }
    }
}