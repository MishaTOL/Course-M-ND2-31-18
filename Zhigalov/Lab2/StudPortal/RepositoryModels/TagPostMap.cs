using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryModels
{
    public class TagPostMap
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }
        public PostEntity Post { get; set; }

        [Required]
        public int TagId { get; set; }
        public TagEntity Tag { get; set; }
    }
}
