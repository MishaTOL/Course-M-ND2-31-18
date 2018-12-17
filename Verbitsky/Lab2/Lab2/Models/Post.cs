using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Header { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public virtual int AuthorId { get; set; }
        public virtual Student Author { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<TagsPosts> TagsPosts { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
        public Post()
        {
            Created = DateTime.Now;
        }
    }
}