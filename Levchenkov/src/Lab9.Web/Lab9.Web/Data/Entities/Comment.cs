using System;
using System.Collections.Generic;

namespace Lab9.Web.Data.Entities
{
    public class Comment
    {
        public int Id
        {
            get;
            set;
        }

        public string AuthorId
        {
            get;
            set;
        }

        public virtual ApplicationUser Author
        {
            get;
            set;
        }

        public int PostId
        {
            get;
            set;
        }

        public virtual Post Post
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public DateTime Created
        {
            get;
            set;
        }

        public virtual IEnumerable<CommentLike> Likes
        {
            get;
            set;
        }
    }
}
