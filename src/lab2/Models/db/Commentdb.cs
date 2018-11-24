using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models.db
{
    public class Commentdb
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public int PostId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? Created { get; set; }
    }
}