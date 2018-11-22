using System;

namespace Domain.Contracts.Models
{
    public class CommentView
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? Created { get; set; }

        public int AuthorId { get; set; }
        public StudentView Author { get; set; }

        public int PostId { get; set; }
        public PostView Post { get; set; }
    }
}
