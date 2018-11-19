using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Lab2.Business.Abstraction.Entity
{
    public class Comment
    { 
        public int Id { get; set; }

        public string Content { get; set; }

        public int StudentId { get; set; }

        public int PostId { get; set; }

        public Student Author { get; set; }

        public Post Post { get; set; }
    }
}
