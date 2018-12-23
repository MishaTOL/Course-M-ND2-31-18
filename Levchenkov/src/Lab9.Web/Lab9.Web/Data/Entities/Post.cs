using System;
using System.Collections.Generic;

namespace Lab9.Web.Data.Entities
{
    public class Post
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

        public virtual IEnumerable<Comment> Comments
        {
            get;
            set;
        }

        public virtual IEnumerable<PostLike> Likes
        {
            get;
            set;
        }
    }

}
