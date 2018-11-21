using Students.RepositoryModel;
using Students.ServicesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Services.Services
{
    public class PostsService : AbstractService<PostInfo, Post>//IStudentsService
    {
        //private IEntityRepository<Post> postRepository = new EntityFrameworkRepository.PostRepository();
        public PostsService()
                : base(new EntityFrameworkRepository.PostRepository())
        {

        }
    }
}
