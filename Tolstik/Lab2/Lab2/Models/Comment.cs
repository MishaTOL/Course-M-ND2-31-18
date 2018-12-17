using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}