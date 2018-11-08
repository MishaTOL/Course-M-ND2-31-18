using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<TagsPosts> TagsPosts { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}