using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepositoryModels
{
    public class TagEntity
    {
        public TagEntity()
        {
            this.Posts = new HashSet<TagPostMap>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<TagPostMap> Posts { get; set; }
    }
}