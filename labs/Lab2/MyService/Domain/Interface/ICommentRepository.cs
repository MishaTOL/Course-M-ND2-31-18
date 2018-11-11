
using Lab2.MyService.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MyService.Domain.Interface
{
    public interface ICommentRepository : IDisposable
    {
        IEnumerable<Comment> GetCommentList();
        Comment Get(int id);
        void Create(Comment item);
        void Update(Comment item);
        void Delete(int id);
        void Save();
    }
}
