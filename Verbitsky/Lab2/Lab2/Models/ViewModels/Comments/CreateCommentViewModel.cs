using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models.ViewModels.Comments
{
    public class CreateCommentViewModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment")]
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}