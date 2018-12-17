using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels
{
    public class CommentInfo
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public StudentInfo Author { get; set; }
        public DateTime Created { get; set; }
        public int PostId { get; set; }
        public PostInfo Post { get; set; }
    }
}
