using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.ViewModels.Posts
{
    public class EditPostViewModel
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
        public int AuthorId { get; set; }
    }
}