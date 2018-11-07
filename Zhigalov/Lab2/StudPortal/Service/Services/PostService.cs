using Repository.Repositories;
using RepositoryModels;
using Service.Interfaces;
using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PostService : IPostService
    {
        PostRepository repository;

        public PostService()
        {
            repository = new PostRepository();
        }

        public void Create(PostInfo post)
        {
            var postEntity = AutoMapper.Mapper.Map<PostEntity>(post);
            repository.Create(postEntity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<PostInfo> GetAll()
        {
            var posts = AutoMapper.Mapper.Map<IEnumerable<PostInfo>>(repository.GetAll());
            return posts;
        }

        public PostInfo GetById(int id)
        {
            var postEntity = repository.GetById(id);
            var postInfo = AutoMapper.Mapper.Map<PostInfo>(postEntity);
            return postInfo;
        }

        public void Edit(PostInfo post)
        {
            var postEntity = AutoMapper.Mapper.Map<PostEntity>(post);
            repository.Update(postEntity);
        }
    }
}
