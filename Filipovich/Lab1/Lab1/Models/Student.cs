using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int yearOfEntering{ get; set; }
        public string specialty { get; set; }
    }
}