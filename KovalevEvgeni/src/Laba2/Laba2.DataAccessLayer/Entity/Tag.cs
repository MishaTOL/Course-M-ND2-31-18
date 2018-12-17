using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.DataAccessLayer.Entity
{
    public  class Tag
    {
        public int TagId { get; set; }
        public string Details { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Tag()
        {
            Posts = new HashSet<Post>(); 
        }
       
    }
}
