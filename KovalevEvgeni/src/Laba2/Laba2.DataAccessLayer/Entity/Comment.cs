using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.DataAccessLayer.Entity
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public int PostId { get; set; }
        public DateTime DateCreate { get; set; }
        public string Details { get; set; }

        public virtual Student Student { get; set; }
    }
}
