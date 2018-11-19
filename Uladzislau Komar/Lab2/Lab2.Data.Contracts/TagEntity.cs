using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab2.Data.Contracts
{
    public class TagEntity
    {
        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<PostEntity> Posts { get; set; }
    }
}
