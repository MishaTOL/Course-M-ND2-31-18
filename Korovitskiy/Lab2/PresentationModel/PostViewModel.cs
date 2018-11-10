using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public StudentViewModel Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<CommentViewModel> Comments { get; set; }
        public virtual ICollection<TagViewModel> Tags { get; set; }

        public string Signature { get { return this.ToString(); } }

        public override string ToString()
        {
            return string.Concat(Author.ToString(), " (", CreatedDate.ToString(), ")");
        }

        [Display(Name = "Space separated tags")]
        public string TagsString { get; set; }
    }
}
