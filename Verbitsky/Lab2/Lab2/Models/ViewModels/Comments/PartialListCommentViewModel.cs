using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.ViewModels.Comments
{
    public class PartialListCommentViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment")]
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public int PostId { get; set; }
    }
}