using System;
using System.Collections.Generic;
using System.Text;

namespace Students.ServicesModel
{
    public class CommentInfo
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public StudentInfo Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PostId { get; set; }
        public PostInfo Post { get; set; }
    }
}
