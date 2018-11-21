using System;
using System.Collections.Generic;

namespace Domain.Contracts.Models
{
    public class PostView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Created { get; set; }

        public int AuthorId { get; set; }
        public StudentView Author { get; set; }

        public ICollection<CommentView> Comments { get; set; }
        public ICollection<TagView> Tags { get; set; }
    }
}
