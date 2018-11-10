using System;
using System.Collections.Generic;
using System.Text;

namespace Students.RepositoryModel
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
