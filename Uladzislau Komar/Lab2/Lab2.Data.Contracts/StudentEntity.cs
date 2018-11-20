using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab2.Data.Contracts
{
    public class StudentEntity
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
    }
}
