using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPostService : IService<PostInfo>
    {
        PostInfo GetById(int id);
        void Edit(PostInfo post);
    }
}
