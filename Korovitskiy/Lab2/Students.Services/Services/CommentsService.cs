using Students.RepositoryModel;
using Students.ServicesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Services.Services
{
    public class CommentsService : AbstractService<CommentInfo, Comment>//IStudentsService
    {
        //private IEntityRepository<Comment> CommentRepository = new EntityFrameworkRepository.CommentRepository();
        public CommentsService()
                : base(new EntityFrameworkRepository.CommentRepository())
        {

        }
    }
}
