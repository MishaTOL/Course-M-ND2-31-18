using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.DataAccessLayer.Entity
{
   public  class Post
    {
        public int PostId { get; set; }
        public int StudentId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreate { get; set; }

        public Student Student { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Tags = new HashSet<Tag>();
            Comments = new List<Comment>();
        }
    }
}
