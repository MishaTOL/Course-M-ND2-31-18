using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Lab1.Models
{
    public class StudBase : StudBaseList
    {
        private static string DbPath = $"{AppDomain.CurrentDomain.BaseDirectory}/App_Data/StudDB.json";
        private List<Student> Students;

        public StudBase()
        {
            Students = DbStudListGet();
        }

        public List<Student> StudentList()
        {
            return Students;
        }

        public List<Student> DbStudListGet()
        {
            var DbFile = File.ReadAllText(DbPath);
            return JsonConvert.DeserializeObject<List<Student>>(DbFile);
        }

        public void DbStudListSave()
        {
            string contDb = JsonConvert.SerializeObject(Students);
            File.WriteAllText(DbPath, contDb);
        }

        public Student ShowStudent(int id)
        {
            return Students.First(stud => stud.Id == id);
        }

        public void AddStudent(Student st)
        {
            if (Students.Count != 0)
            {
                var stLast = Students.Last();
                st.Id = (stLast.Id + 1);
            }
            else
            {
                st.Id = 1;
            }
            Students.Add(st);
            DbStudListSave();
        }

        public void EditStudent(Student st)
        {
            var StudEdit = ShowStudent(st.Id);
            var StudEditId = Students.IndexOf(StudEdit);
            Students[StudEditId] = st;
            DbStudListSave();
        }

        public void DeleteStudent(int id)
        {
            Students.RemoveAll(Students => Students.Id == id);
            DbStudListSave();
        }
    }
}