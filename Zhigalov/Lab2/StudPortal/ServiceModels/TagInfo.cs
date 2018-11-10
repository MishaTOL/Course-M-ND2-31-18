using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModels
{
    public class TagInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TagPostMapInfo> Posts { get; set; }
    }
}
