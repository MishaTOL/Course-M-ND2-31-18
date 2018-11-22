using System;
using System.Collections.Generic;

namespace Data.Contracts.Models
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Created { get; set; }

        public int AuthorId { get; set; }
        public Student Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        private ICollection<Tag> tags;
        public virtual ICollection<Tag> Tags
        {
            get
            {
                return this.tags ?? (this.tags = new List<Tag>());
            }
            set
            {
                tags = value;
            }
        }
    }
}
