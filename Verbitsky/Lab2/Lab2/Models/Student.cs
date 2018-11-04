using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}