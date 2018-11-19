using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_Lab1.ViewModels.Post
{
    public class AddView
    {
        public int StudentId { get; set; }
        public string NickName { get; set; }
        [Remote("CheckDuplicateString", "Post", ErrorMessage = "Duplicate tags")]
        public string TagsString { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}