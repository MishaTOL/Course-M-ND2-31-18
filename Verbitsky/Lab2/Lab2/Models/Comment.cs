using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public virtual int AuthorId { get; set; }
        public virtual Student Author { get; set; }
        public DateTime Created { get; set; }
        public virtual int PostId { get; set; }
        public virtual Post Post { get; set; }
        public Comment()
        {
            Created = DateTime.Now;
        }
    }
}