using AutoMapper;
using DBModels.Models;
using DBRepConUow.Repositarys;
using DBRepConUow.UnitOfWork;
using Lab2_Lab1.InfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Lab1.Services
{
    public class PostService:IService<Post>
    {
        private IForumUOW forumUOW;
        private Post MapPostInfoToPost(PostInfo postInfo)
        {
            return Mapper.Map<PostInfo, Post>(postInfo);
        }
        private PostInfo MapPostToPostInfo(Post post)
        {
            return Mapper.Map<Post, PostInfo>(post);
        }
        private ICollection<Tag> TagStringToTag(string tagString)
        {
            IEnumerable<string> splitList = tagString.Split(' ').Distinct().ToList();
            List<Tag> tagList = new List<Tag>();
            foreach (string item in splitList)
            {
                Tag tag = ((TagRepositary)(forumUOW.TagRepositary)).GetByName(item);
                if (tag == null)
                {
                    tagList.Add(new Tag
                    {
                        Name = item
                    });
                }
                else
                {
                    tagList.Add(tag);
                }
            }
            return tagList;
        }
        private string TagToTagString(IEnumerable<Tag> Tags)
        {
            string result = "";
            foreach (var item in Tags)
            {
                result += $"{item.Name} "; 
            }
            return result;
        }

        public PostService(IForumUOW forumUOW)
        {
            this.forumUOW = forumUOW;
        }
        public void Add(PostInfo postInfo)
        {
            Student student = forumUOW.StudentRepositary.Get(postInfo.StudentId);
            Post post = MapPostInfoToPost(postInfo);
            post.Created = DateTime.Now;
            post.Tags = TagStringToTag(postInfo.TagsString);
            student.Posts.Add(post);
            forumUOW.Save();
        }
        public void Edit(PostInfo postInfo)
        {
            Post post = forumUOW.PostRepositary.Get(postInfo.PostId);
            post.Content = postInfo.Content;
            post.Tags.Clear();
            post.Tags = TagStringToTag(postInfo.TagsString);
            forumUOW.PostRepositary.Update(post);
            forumUOW.Save();
        }
        public IEnumerable<PostInfo> GetPosts()
        {
            var posts = forumUOW.PostRepositary.GetAll();
            IEnumerable<PostInfo> postsInfos = new List<PostInfo>();    
            foreach (Post item in posts)
            {
                var postInfo = MapPostToPostInfo(item);
                postInfo.TagsString = TagToTagString(item.Tags);
                ((List<PostInfo>)(postsInfos)).Add(postInfo); 
            }

            return postsInfos;
        }
        public void Remove(PostInfo postInfo)
        {
            ((PostRepositary)(forumUOW.PostRepositary)).DeleteById(postInfo.PostId);
            forumUOW.Save();
        }

        
    }
}