using Lab2.Business.Abstraction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Business.Abstraction
{
    public interface ICommentService
    {
        void AddComment(Comment comment,int postId);
        List<Comment> GetComments(int postId);
    }
}
