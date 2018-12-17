using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsAutomationProject.Models
{
    public class StudentViewModel
    {
        [Display(Name = nameof(Id))]
        public int? Id { get; set; }

        [Display(Name = nameof(Name))]
        public string Name { get; set; }

        [Display(Name = nameof(Course))]
        public int Course { get; set; }
    }
}