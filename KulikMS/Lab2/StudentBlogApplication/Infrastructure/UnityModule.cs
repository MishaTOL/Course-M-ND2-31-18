using Data.Contracts.Models;
using Data.Contracts.Repositories;
using Data.Repositories;
using Domain.Contracts;
using Domain.Contracts.Models;
using Domain.Contracts.Services;
using Domain.Services;
using Unity;

namespace Infrastructure
{
    public class UnityModule
    {
        public IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IRepository<Post>, PostRepository>();
            container.RegisterType<IRepository<Tag>, TagRepository>();
            container.RegisterType<IService<StudentView>, Service<StudentView, Student>>();
            container.RegisterType<IService<PostView>, Service<PostView, Post>>();
            container.RegisterType<IService<CommentView>, Service<CommentView, Comment>>();
            container.RegisterType<IService<TagView>, Service<TagView, Tag>>();
            container.RegisterType(typeof(IMapper<,>), typeof(Mapper<,>));
            container.RegisterInstance(new AutoMapperConfiguration().ConfigureMapper());
            container.RegisterInstance(new StudentBlogContext());

            return container;
        }

    }
}
