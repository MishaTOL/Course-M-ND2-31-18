using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CommentId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}