using Lab2.Business.Abstraction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int StudentId { get; set; }

        public int PostId { get; set; }

        public Student Author { get; set; }

        public Post Post { get; set; }
    }
}