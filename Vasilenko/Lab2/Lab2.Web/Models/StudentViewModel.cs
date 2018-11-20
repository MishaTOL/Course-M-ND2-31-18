using Lab2.Business.Abstraction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Web.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}