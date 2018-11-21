using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class TagViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PostViewModel> Posts { get; set; }
    }
}
