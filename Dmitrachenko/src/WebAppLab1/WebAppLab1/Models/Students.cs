using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppLab1.Models
{
    public class Students
    {
        //[HiddenInput]
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display (Name = "Имя")]
        public string FirstName { get; set; }

        [Display (Name ="Фамилия")]
        public string LastName { get; set; }
    }
}