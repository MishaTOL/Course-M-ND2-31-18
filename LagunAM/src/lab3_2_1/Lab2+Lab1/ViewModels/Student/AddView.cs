using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_Lab1.ViewModels.Student
{
    public class AddView
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Remote("CheckNickName", "Student", ErrorMessage = "Nick Name In Use")]
        public string NickName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Not Valid Email")]
        [Remote("CheckEmail", "Student", ErrorMessage = "Email In Use")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Pass", ErrorMessage = "Password is  Differ")]
        [DataType(DataType.Password)]
        public string PassCopy { get; set; }
    }
}