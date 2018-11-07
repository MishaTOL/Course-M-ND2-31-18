using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepositoryModels
{
    public class PostEntity
    {
        public PostEntity()
        {
            this.Comments = new HashSet<CommentEntity>();
            this.Tags = new HashSet<TagPostMap>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public StudentEntity Author { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public IEnumerable<CommentEntity> Comments { get; set; }
        public IEnumerable<TagPostMap> Tags { get; set; }
    }
}