using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laba2.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int StudentId { get; set; }
        public int PostId { get; set; }
        public DateTime DateCreate { get; set; }
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }
        public string Author { get; set; }
    }
}