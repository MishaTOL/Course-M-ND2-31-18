using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Laba1.Models
{
    [DataContract]
    public class Student
    {
        #region Переменые
        [DataMember]
        [Display(Name ="ID")]
        public int StudentId { get; set; }
        [DataMember]
        [Display(Name = "Имя")]
        public string LastName { get; set; }
        [DataMember]
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        [DataMember]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [DataMember]
        [Display(Name = "Наименование курса")]
        public string CourseName { get; set; }
        #endregion

        #region Конструктор

        #endregion

        #region Методы

        #endregion
    }
}