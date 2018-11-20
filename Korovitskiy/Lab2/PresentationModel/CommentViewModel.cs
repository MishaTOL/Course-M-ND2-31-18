using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public StudentViewModel Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PostId { get; set; }
        public PostViewModel Post { get; set; }

        public string Signature { get { return this.ToString(); } }

        public override string ToString()
        {
            return string.Concat(Author.ToString(), " (", CreatedDate.ToString(), ")");
        }
    }
}
