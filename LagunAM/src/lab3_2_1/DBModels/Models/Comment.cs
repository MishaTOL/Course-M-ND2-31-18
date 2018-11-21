using System;

namespace DBModels.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
       
    }
}
