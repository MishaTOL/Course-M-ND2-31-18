using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Student
    {
        public Student() { }

        [Display(Name = "ID студента")]
        public int StudentId { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        //[Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}