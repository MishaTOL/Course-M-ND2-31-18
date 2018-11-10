
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class CurrentStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public CurrentStudent()
        {
            Posts = new List<Post>();
        }
    }
}