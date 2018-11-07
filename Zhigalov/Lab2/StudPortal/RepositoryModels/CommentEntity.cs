using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryModels
{
    public class CommentEntity
    {
        public CommentEntity()
        {

        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public StudentEntity Author { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int PostId { get; set; }
        public PostEntity Post { get; set; }
    }
}