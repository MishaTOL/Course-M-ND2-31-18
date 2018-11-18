using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<PostViewModel> Posts { get; set; }
        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public string FullName { get { return this.ToString(); } }

        public override string ToString()
        {
            return string.Concat(LastName, " ", FirstName);
        }
    }
}