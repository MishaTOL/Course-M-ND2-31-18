using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab2_Lab1.ViewModels.Post
{
    public class EditView
    {
        public int StudentId { get; set; }
        public string NickName { get; set; }
        public int PostId { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [Remote("CheckDuplicateString", "Post", ErrorMessage = "Duplicate tags")]
        public string TagsString { get; set; }
    }
}