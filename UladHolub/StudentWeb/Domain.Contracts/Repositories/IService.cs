using Domain.Contracts.ViewModel;
using System.Collections.Generic;

namespace Domain.Contracts.Repositories
{
    public interface IService
    {
        StudentViewModel GetOrCreateStudent(StudentViewModel studentViewModel);
        StudentViewModel GetStudent(int id);
        void CreatePost(PostViewModel postViewModel, string tagString);
        void UpdatePost(PostViewModel postViewModel, string tagString);
        PostViewModel GetPost(int id);
        IEnumerable<PostViewModel> GetAllPosts();
        void DeletePost(int id);
        void CreateComment(CommentViewModel commentViewModel);
        void UpdateComment(CommentViewModel commentViewModel);
        CommentViewModel GetComment(int id);
        IEnumerable<CommentViewModel> GetAllComments();
        void DeleteComment(int id);
    }
}
