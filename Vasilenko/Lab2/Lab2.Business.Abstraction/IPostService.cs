using Lab2.Business.Abstraction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2.Business.Abstraction
{
    public interface IPostService
    {
        List<Post> GetPosts(int studentId);
        void AddPost(Post post,int studentId);
        void UpdatePost(Post post);
        int DeletePost(int id);
        Post FindPost(int id);
    }
}
