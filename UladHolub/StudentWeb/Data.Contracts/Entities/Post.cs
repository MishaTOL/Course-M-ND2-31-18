using System;
using System.Collections.Generic;

namespace Data.Contracts.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public int? AuthorId { get; set; }
        public virtual Student Author { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}
