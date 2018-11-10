using AutoMapper;
using Lab2.Data.Contracts;
using Lab2.Data.Implementation;
using Lab2.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Domain.Implementation
{
    public class TagService
    {
        private TagRepository repository;

        public TagService()
        {
            repository = new TagRepository();
        }

        public List<TagViewModel> GetPostTags(int postId)
        {
            PostService postService = new PostService();
            var post = postService.GetPostById(postId);
            return post.Tags.ToList();
        }

        public void AddTags(int postId, string tagString)
        {
            if (tagString != string.Empty)
            {
                var tags = tagString.Split(',');
                PostService postService = new PostService();
                var post = postService.GetPostById(postId);
                foreach (var tag in tags)
                {
                    var model = new TagEntity
                    {
                        Name = tag,
                        Posts = new List<PostEntity>()
                    };
                    repository.Create(postId, model);
                    var tagModel = Mapper.Map<TagEntity, TagViewModel>(model);
                    post.Tags.Add(tagModel);
                }
            }
        }
    }
}
