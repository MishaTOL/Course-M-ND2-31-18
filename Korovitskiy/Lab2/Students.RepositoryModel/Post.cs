using System;
using System.Collections.Generic;
using System.Text;

namespace Students.RepositoryModel
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public virtual Student Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
