using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.ViewModels.Student
{
    public class EditView
    {
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Pass", ErrorMessage = "Password is  Differ")]
        [DataType(DataType.Password)]
        public string PassCopy { get; set; }
    }
}