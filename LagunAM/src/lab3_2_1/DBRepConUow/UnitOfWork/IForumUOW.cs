using DBModels.Models;
using DBRepConUow.Repositarys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepConUow.UnitOfWork
{
    public interface IForumUOW
    {
        IRepositary<int, Student> StudentRepositary { get; }
        IRepositary<int, Post> PostRepositary { get; }
        IRepositary<int, Comment> CommentRepositary { get; }
        IRepositary<int, Tag> TagRepositary { get; }
        void Save();
    }
}
