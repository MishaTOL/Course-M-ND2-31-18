using Lab2.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Lab2.Data.Contracts;
using Lab2.Data.Implementation;

namespace Lab2.Domain.Implementation
{
    public class PostService
    {
        private PostRepository repository;
        public PostService()
        {
            repository = new PostRepository();
        }

        public List<PostViewModel> GetPosts()
        {
            List<PostViewModel> output = new List<PostViewModel>();
            var posts = repository.Read();
            output = Mapper.Map<List<PostEntity>, List<PostViewModel>>(posts);
            foreach (var item in posts)
            {
                var model = Mapper.Map<PostEntity, PostViewModel>(item);
                output.Add(model);
            }
            return output;
        }

        public PostViewModel GetPostById(int id)
        {
            var model = repository.Read(id);
            var output = Mapper.Map<PostEntity, PostViewModel>(model);
            return output;
        }
        
        public void CreatePost(PostViewModel post)
        {
            var model = Mapper.Map<PostViewModel, PostEntity>(post);
            repository.Create(model);
        }

        public void EditPost(PostViewModel post)
        {
            var model = Mapper.Map<PostViewModel, PostEntity>(post);
            repository.Update(model);
        }

        public void DeletePost(int id)
        {
            repository.Delete(id);
        }
    }
}
