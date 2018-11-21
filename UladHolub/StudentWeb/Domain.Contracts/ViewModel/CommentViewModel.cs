using System;

namespace Domain.Contracts.ViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public int? AuthorId { get; set; }
        public virtual StudentViewModel Author { get; set; }
        public int? PostId { get; set; }
        public virtual PostViewModel Post { get; set; }
    }
}
