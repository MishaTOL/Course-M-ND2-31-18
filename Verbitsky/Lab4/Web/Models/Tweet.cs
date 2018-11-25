using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Head { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
    }
}
