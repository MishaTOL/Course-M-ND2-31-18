using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab2.Data.Contracts
{
    public class PostEntity
    {
        [Key]
        public int PostId { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public StudentEntity Author { get; set; }

        public DateTime Created { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<TagEntity> Tags { get; set; }
    }
}
