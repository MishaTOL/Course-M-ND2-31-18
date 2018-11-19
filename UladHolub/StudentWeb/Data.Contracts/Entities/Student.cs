using System.Collections.Generic;

namespace Data.Contracts.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Student()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
    }
}
