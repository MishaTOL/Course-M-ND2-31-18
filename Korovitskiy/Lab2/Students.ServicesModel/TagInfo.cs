using System;
using System.Collections.Generic;
using System.Text;

namespace Students.ServicesModel
{
    public class TagInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PostInfo> Posts { get; set; }
    }
}
