using Lab2.MyService.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.ViewCRUD
{
    public class IndexViewPost
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? Created { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
        //public IEnumerable<Tags> Tags { get; set; }
    }
}