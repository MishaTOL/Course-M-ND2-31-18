using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Post> Comments { get; set; }

        public Student()
        {
            Posts = new List<Post>();
        }
    }
}