using Data.Contracts.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Data.Repositories
{
    public class JsonContext
    {
        private string connectionString;

        public JsonContext()
        {
            connectionString = HttpContext.Current.Server.MapPath("~/App_Data/StudentDataBase.txt");
        }

        public IEnumerable<Student> ReadDataBase()
        {
            string json = File.ReadAllText(connectionString);
            IEnumerable<Student> studentList = JsonConvert.DeserializeObject<IEnumerable<Student>>(json);
            return studentList.ToList();
        }

        public void WriteDataBase(IEnumerable<Student> studentList)
        {
            string json = JsonConvert.SerializeObject(studentList, Formatting.Indented);
            File.WriteAllText(connectionString, json);
        }
    }
}
