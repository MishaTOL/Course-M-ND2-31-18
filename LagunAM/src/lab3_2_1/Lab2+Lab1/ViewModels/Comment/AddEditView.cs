using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.ViewModels.Comment
{
    public class AddEditView
    {
        public int StudentId { get; set; }
        public int NickName { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}