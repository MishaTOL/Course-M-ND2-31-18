﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}