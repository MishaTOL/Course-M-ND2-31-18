using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Labs2.DataAccess.Entity
{
    public class Post
    {
        public Post()
        {
            Tags = new List<Tag>();
            Comments = new List<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("Author")]
        public int StudentId { get; set; }
        
        public Student Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}