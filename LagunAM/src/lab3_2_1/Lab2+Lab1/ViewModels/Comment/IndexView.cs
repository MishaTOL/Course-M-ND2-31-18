using Lab2_Lab1.InfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.ViewModels.Comment
{
    public class IndexView
    {
        public int StudentId { get; set; }
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<CommentInfo> Comments{ get; set; }
    }
}