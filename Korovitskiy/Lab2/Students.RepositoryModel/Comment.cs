using System;
using System.Collections.Generic;
using System.Text;

namespace Students.RepositoryModel
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public Student Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
