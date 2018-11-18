using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Domain.Contracts
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public StudentViewModel Author { get; set; }

        public DateTime Created { get; set; }

        public int PostId { get; set; }
        public PostViewModel Post { get; set; }
    }
}
