using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.ViewModels.Posts
{
    public class DetailsPostViewModel
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
        public virtual int AuthorId { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tags> Tags { get; set; }
    }
}