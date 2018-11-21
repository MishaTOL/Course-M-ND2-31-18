using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labs2.DataAccess.Entity
{
    public class Tag
    {
        public Tag()
        {
            Posts = new List<Post>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}