
using Lab2.MyService.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MyService.Domain.Interface
{
    public interface ITagsRepository : IDisposable
    {
        IEnumerable<Tags> GetTagsList();
        Tags Get(int id);
        void Create(Tags item);
        void Update(Tags item);
        void Delete(int id);
        void Save();
    }
}
