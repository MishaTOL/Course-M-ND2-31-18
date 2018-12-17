using Laba2.BusinessLogicLayer.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.BusinessLogicLayer.Interfaces
{
   public interface IServicePost
    {
        IEnumerable<PostDTO> GetPostes(int studentId);
        PostDTO GetPost(int postId);

        void Insert(PostDTO record);
        void Update(PostDTO record);
        void Delete(int postId);
    }
}
