using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Domain.Contracts
{
    public class TagViewModel
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
