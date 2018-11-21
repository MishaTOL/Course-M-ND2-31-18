using Lab2_Lab1.InfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.ViewModels.Post
{
    public class IndexView
    {
        public int StudentId { get; set; }
        public string NickName { get; set; }
        public IEnumerable<PostInfo> Posts { get; set; }
    }
}