using System.Collections.Generic;

namespace Domain.Contracts.ViewModel
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PostViewModel> Posts { get; set; }

        public TagViewModel()
        {
            Posts = new List<PostViewModel>();
        }
    }
}
