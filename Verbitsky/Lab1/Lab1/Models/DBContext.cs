using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;
using System.IO;    

namespace Lab1.Models
{
    public class DBContext
    {
        private string Path;
        public DBContext(string Path)
        {
            this.Path = Path;
            try
            {
                if (!File.Exists(Path))
                    File.Create(Path).Dispose();
            }catch {
                throw new Exception("Укажите путь к json файлу (Lab1/Controllers/)");
            }
        }
        public void Update(Student student)
        {
            Delete(student.id.Value);
            Create(student);
        }
        public List<Student> Read()
        {
            List<Student> students = new List<Student>();
            using(var stream = new StreamReader(Path))
                while(!stream.EndOfStream)
                    students.Add(JsonConvert.DeserializeObject<Student>(stream.ReadLine()));
            return students;
        }
        public void Create(Student student)
        {
            if(student.id == null)
            {
                var maxId = Read().Max(a => a.id) + 1;
                student.id = (maxId == null) ? 0 : maxId.Value;
            }
            using(var stream = new StreamWriter(Path, true))
                stream.WriteLine(JsonConvert.SerializeObject(student));
        }
        public void Delete(uint id)
        {
            var list = Read().Where(a => a.id != id);
            File.WriteAllText(Path, (list.Count() == 0) 
                ? "" 
                : list.Select(a => JsonConvert.SerializeObject(a)).Aggregate((a,b) => a + Environment.NewLine + b) + Environment.NewLine);
        }
    }
}