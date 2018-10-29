using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class StudentSummary
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public string Speciality { get; set; }
        public DateTime ReceiptDate { get; set; }
        public double GradePointAverage { get; set; }
    }
}