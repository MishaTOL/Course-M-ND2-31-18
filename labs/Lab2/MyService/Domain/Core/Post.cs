using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MyService.Domain.Core
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime? Created { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
        //public IEnumerable<Tags> Tags { get; set; }
    }
}
