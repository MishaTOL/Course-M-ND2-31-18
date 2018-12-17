using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class TagsPosts
    {
        public int IdTag { get; set; }
        public virtual Tags Tags { get; set; }
        public int IdPost { get; set; }
        public virtual Post Post { get; set; }
    }
}