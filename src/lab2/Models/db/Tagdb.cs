using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models.db
{
    public class Tagdb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }
    }
}