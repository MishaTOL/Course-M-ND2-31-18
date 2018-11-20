using System;
using System.Collections.Generic;

namespace Domain.Contracts.ViewModel
{
    public class PostViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<CommentViewModel> Comments { get; set; }
        public virtual ICollection<TagViewModel> Tags { get; set; }

        public int? AuthorId { get; set; }
        public virtual StudentViewModel Author { get; set; }

        public PostViewModel()
        {
            Comments = new List<CommentViewModel>();
        }
    }
}
