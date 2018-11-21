using System;
using System.Collections.Generic;

namespace Students.ServicesModel
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<PostInfo> Posts { get; set; }
        public virtual ICollection<CommentInfo> Comments { get; set; }
    }
}
