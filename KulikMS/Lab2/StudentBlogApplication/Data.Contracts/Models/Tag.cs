using System.Collections.Generic;

namespace Data.Contracts.Models
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private ICollection<Post> posts;
        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts ?? (this.posts = new List<Post>());
            }
            set
            {
                posts = value;
            }
        }
    }
}
