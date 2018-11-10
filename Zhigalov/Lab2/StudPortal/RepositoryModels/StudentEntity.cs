using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryModels
{
    public class StudentEntity
    {
        public StudentEntity()
        {
            this.Posts = new HashSet<PostEntity>();
            this.Comments = new HashSet<CommentEntity>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public IEnumerable<PostEntity> Posts { get; set; }
        public IEnumerable<CommentEntity> Comments { get; set; }
    }
}
