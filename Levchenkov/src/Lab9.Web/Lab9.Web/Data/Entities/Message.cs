using System;
using System.Collections;

namespace Lab9.Web.Data.Entities
{
    public class Message
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

        public int DialogId
        {
            get;
            set;
        }

        public virtual Dialog Dialog
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
    }


}
