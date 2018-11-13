using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Student
    {
        [Display(Name = "ID студента")]
        public int StudentId { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        //[Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}