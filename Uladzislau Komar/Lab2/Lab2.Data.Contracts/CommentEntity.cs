using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab2.Data.Contracts
{
    public class CommentEntity
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public StudentEntity Author { get; set; }

        public DateTime Created { get; set; }

        public int PostId { get; set; }
        public PostEntity Post { get; set; }
    }
}
