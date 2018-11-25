using Data.Implementation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Implementation.Service
{
    class TweetService
    {
        TweetRepository repository;
        public TweetService()
        {
            repository = new TweetRepository();
        }

        public List<TweetViewModel> GetPosts()
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
