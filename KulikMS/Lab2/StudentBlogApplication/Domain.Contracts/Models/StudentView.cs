using System.Collections.Generic;

namespace Domain.Contracts.Models
{
    public class StudentView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<PostView> Posts { get; set; }
        public ICollection<CommentView> Comments { get; set; }
    }
}
