using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.InfoModels
{
    public class PostInfo
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string TagsString { get; set; }
        public DateTime Created { get; set; }
        public int StudentId{ get; set; }
        public string NickName { get; set; }
    }
}