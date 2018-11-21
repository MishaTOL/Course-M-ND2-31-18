using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.BusinessLogicLayer.DataTransferObject
{
   public  class CommentDTO
    {
        public int CommentId { get; set; }
        public int StudentId { get; set; }
        public int PostId { get; set; }
        public DateTime DateCreate { get; set; }
        public string Details { get; set; }
        public string Author { get; set; }
    }
}
