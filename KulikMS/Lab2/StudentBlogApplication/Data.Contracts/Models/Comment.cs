using System;

namespace Data.Contracts.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? Created { get; set; }

        public int AuthorId { get; set; }
        public Student Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
