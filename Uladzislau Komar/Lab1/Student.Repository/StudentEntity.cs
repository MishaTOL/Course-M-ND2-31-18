using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student.Repository
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Course { get; set; }
    }
}