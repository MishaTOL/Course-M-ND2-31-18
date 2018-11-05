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
                throw new Exception("Specify the path to the json file (Lab1/Controllers/)");
            }
        }
        public void Update(Student student)
        {
            Delete(student.id);
            Create(student);
        }
        public List<Student> Read()
        {
            List<Student> students = new List<Student>();
            using (var stream = new StreamReader(Path))
                while (!stream.EndOfStream)
                    students = JsonConvert.DeserializeObject<Student[]>(stream.ReadToEnd()).ToList();
            return students;
        }
        public void Create(Student student)
        {
            var list = Read();
            if (student.id == 0)
            {
                if (list.Count == 0)
                    student.id = 0;
                else
                {
                    var maxId = list.Max(a => a.id) + 1;
                    student.id = (maxId == 0) ? 1 : maxId;
                }
            }
            using (var stream = new StreamWriter(Path, false))
            {
                list.Add(student);
                stream.WriteLine(JsonConvert.SerializeObject(list.ToArray()));
            }
        }
        public void Delete(int id)
        {
            var list = Read().Where(a => a.id != id);
            using (var stream = new StreamWriter(Path, false))
                stream.WriteLine(JsonConvert.SerializeObject(list.ToArray()));
        }
    }
}