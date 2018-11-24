using Lab2.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? Created { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Tagdb> Tags { get; set; }
    }
}