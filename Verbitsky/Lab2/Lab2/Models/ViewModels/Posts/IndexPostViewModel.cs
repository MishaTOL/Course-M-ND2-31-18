using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.ViewModels.Posts
{
    public class IndexPostViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Header")]
        public string Header { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Content ")]
        public string Content { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        public int AuthorId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
    }
}