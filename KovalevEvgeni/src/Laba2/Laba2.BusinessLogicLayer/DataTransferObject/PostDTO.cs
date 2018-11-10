using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.BusinessLogicLayer.DataTransferObject
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public int StudentId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreate { get; set; }
        public string Author { get; set; }
        public bool OperationRecord { get; set; }
        public string Tags { get; set; }
    }
}
