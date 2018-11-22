using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}