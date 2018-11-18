using AutoMapper;
using Lab2.Data.Contracts;
using Lab2.Data.Implementation;
using Lab2.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Domain.Implementation
{
    public class CommentService
    {
        private CommentRepository repository;
        public CommentService()
        {
            repository = new CommentRepository();
        }

        public List<CommentViewModel> GetPostComments(PostViewModel post)
        {
            List<CommentViewModel> output = new List<CommentViewModel>();
            var comments = repository.Read();
            foreach (var item in comments)
            {
                if(item.PostId == post.PostId)
                {
                    var outputItem = Mapper.Map<CommentEntity, CommentViewModel>(item);
                    output.Add(outputItem);
                }
            }
            return output;
        }

        public void CreateComment(CommentViewModel comment)
        {
            var modelComment = Mapper.Map<CommentViewModel, CommentEntity>(comment);
            repository.Create(modelComment);
        }

        public void DeleteComment(int id)
        {
            repository.Delete(id);
        }

        public CommentViewModel GetCommentById(int id)
        {
            var model = repository.Read(id);
            var output = Mapper.Map<CommentEntity, CommentViewModel>(model);
            return output;
        }
    }
}
