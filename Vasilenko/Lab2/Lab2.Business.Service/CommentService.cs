
using Lab2.Business.Abstraction;
using Lab2.Business.Abstraction.Entity;
using Lab2.DataAccess.Abstraction;
using System.Collections.Generic;
using System.Linq;
using CommentContract = Labs2.DataAccess.Entity.Comment;

namespace Lab2.Business.Service
{
    public class CommentService : ICommentService
    {
        private readonly IContextFactory contextFactory;

        public CommentService(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public void AddComment(Comment comment, int postId)
        {
            using (var context = contextFactory.GetContext())
            {
                context.Add(context.CommentsRepository, new CommentContract()
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    PostId = postId,
                    StudentId = comment.StudentId
                });
                context.Save();
            }
        }
        public List<Comment> GetComments(int postId)
        {
            using (var context = contextFactory.GetContext())
            {
                if (postId != 0)
                {

                    var comments = context.CommentsRepository.Where(x => x.PostId==postId)
                    .Join(context.StudentsRepository, p => p.StudentId, x => x.Id, (p, x) => new Comment()
                    {
                        Author = new Student() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName },
                        Id = p.Id,
                        Content = p.Content,
                        PostId= p.PostId,
                        StudentId= p.StudentId                      
                    }).ToList();

                    return comments;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}