
using Lab2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.MyService.Domain.Interface
{

    public interface IPostRepository : IDisposable
    {
        IEnumerable<Post> GetPostList();
        Post Get(int id);
        void Create(Post item);
        void Update(Post item);
        void Delete(int id);
        void Save();
    }
}
