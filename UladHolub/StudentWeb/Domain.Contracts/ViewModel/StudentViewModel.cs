using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<PostViewModel> Posts { get; set; }
        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public StudentViewModel()
        {
            Posts = new List<PostViewModel>();
            Comments = new List<CommentViewModel>();
        }
    }
}
