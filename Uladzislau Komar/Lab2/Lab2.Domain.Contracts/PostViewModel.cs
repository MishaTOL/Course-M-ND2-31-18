using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Domain.Contracts
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public StudentViewModel Author { get; set; }

        public DateTime Created { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
        public ICollection<TagViewModel> Tags { get; set; }
    }
}
