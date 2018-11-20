using System;

namespace Data.Contracts.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public int? AuthorId { get; set; }
        public virtual Student Author { get; set; }
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
