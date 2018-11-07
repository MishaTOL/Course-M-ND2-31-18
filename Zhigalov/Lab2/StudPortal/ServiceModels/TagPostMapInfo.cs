using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels
{
    public class TagPostMapInfo
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        public PostInfo Post { get; set; }

        public int TagId { get; set; }
        public TagInfo Tag { get; set; }
    }
}
