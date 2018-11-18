using System;
using System.Collections.Generic;

namespace DBModels.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public DateTime Created { get; set; }

        public virtual Student Student{ get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
