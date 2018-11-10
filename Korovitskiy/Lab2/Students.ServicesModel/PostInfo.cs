using System;
using System.Collections.Generic;
using System.Text;

namespace Students.ServicesModel
{
    public class PostInfo
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public StudentInfo Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<CommentInfo> Comments { get; set; }
        public virtual ICollection<TagInfo> Tags { get; set; }
    }
}
