using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.ViewModels.Student
{
    public class LoginView
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Pass { get; set; }
        [Display(Name = "Login Failed")]
        public bool Error { get; set; }
    }
}