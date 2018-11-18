using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Labs2.DataAccess.Entity
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("Author")]
        public int StudentId { get; set; }

        public int PostId { get; set; }

        public Student Author { get; set; }

        public Post Post { get; set; }
    }
}