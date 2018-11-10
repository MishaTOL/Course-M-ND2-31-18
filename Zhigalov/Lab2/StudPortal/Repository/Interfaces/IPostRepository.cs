using RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPostRepository : IRepository<PostEntity>
    {
        void Update(PostEntity post);
        PostEntity GetById(int id);
    }
}
