using System.Collections.Generic;

namespace Domain.Contracts.Models
{
    public class TagView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostView> Posts { get; set; }
    }
}
