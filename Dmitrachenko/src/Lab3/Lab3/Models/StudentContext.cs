using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("DefaultConnection") { }

        public DbSet<Student> Students { get; set; }
    }

    public interface IRepository
    {
        void Save(Student student);
        IEnumerable<Student> List();
        Student Get(int id);
    }
}