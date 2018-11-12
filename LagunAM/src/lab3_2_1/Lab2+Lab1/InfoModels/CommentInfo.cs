using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.InfoModels
{
    public class CommentInfo
    {
        public int StudentId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string Content {get; set;}
        public DateTime Created { get; set; }
    }
}