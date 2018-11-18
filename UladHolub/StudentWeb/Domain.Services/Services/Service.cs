using Data.Contracts.Entities;
using Data.Contracts.Repositories;
using Domain.Contracts.Repositories;
using Domain.Contracts.ViewModel;
using Domain.Services.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services.Services
{
    public class Service : IService
    {
        private IUnitOfWork database { get; set; }

        public Service(IUnitOfWork iUnitOfWork)
        {
            database = iUnitOfWork;
        }

        public StudentViewModel GetOrCreateStudent(StudentViewModel studentViewModel)
        {
            var students = database.Students.Find(x => x.FirstName == studentViewModel.FirstName
                && x.LastName == studentViewModel.LastName);
            if (students.Count() == 0)
            {
                var student = DomainMapper.Mapper.Map<StudentViewModel, Student>(studentViewModel);
                database.Students.Create(student);
                database.Save();
                return DomainMapper.Mapper.Map<Student, StudentViewModel>(student);
            }
            var firstItem = students.First();
            return DomainMapper.Mapper.Map<Student, StudentViewModel>(firstItem);
        }

        public StudentViewModel GetStudent(int id)
        {
            var student = database.Students.Get(id);
            if (student == null) { return null; }
            return DomainMapper.Mapper.Map<Student, StudentViewModel>(student);
        }

        public void CreatePost(PostViewModel postViewModel, string tagString)
        {
            var post = DomainMapper.Mapper.Map<PostViewModel, Post>(postViewModel);
            post.Tags = SeparateAndFindTags(tagString);
            post.Created = DateTime.Now;
            database.Posts.Create(post);
            database.Save();
        }
        public void UpdatePost(PostViewModel postViewModel, string tagString)
        {
            var post = database.Posts.Get(postViewModel.Id);
            if(post == null) { return; }
            post.Tags = SeparateAndFindTags(tagString);
            post.Title = postViewModel.Title;
            post.Content = postViewModel.Content;
            database.Posts.Update(post);
            database.Save();
        }

        private List<Tag> SeparateAndFindTags(string tagString)
        {
            var tags = tagString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var tagList = new List<Tag>();
            foreach(var tag in tags)
            {
                var tagEntity = database.Tags.Find(x => x.Name == tag).FirstOrDefault();
                if(tagEntity == null)
                {
                    tagEntity = new Tag() { Name = tag };
                    database.Tags.Create(tagEntity);
                    tagList.Add(tagEntity);
                }
                else { tagList.Add(tagEntity); }
            }
            database.Save();
            return tagList;
        }
        public PostViewModel GetPost(int id)
        {
            var post = database.Posts.Get(id);
            return DomainMapper.Mapper.Map<Post, PostViewModel>(post);
        }

        public IEnumerable<PostViewModel> GetAllPosts()
        {
            var posts = database.Posts.GetAll();
            return DomainMapper.Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(posts);
        }

        public void DeletePost(int id)
        {
            database.Posts.Delete(id);
            database.Save();
        }

        public void CreateComment(CommentViewModel commentViewModel)
        {
            var comment = DomainMapper.Mapper.Map<CommentViewModel, Comment>(commentViewModel);
            comment.Created = DateTime.Now;
            database.Comments.Create(comment);
            database.Save();
        }

        public void UpdateComment(CommentViewModel commentViewModel)
        {
            var comment = database.Comments.Get(commentViewModel.Id);
            if (comment == null) { return; }
            comment.Content = commentViewModel.Content;
            database.Comments.Update(comment);
            database.Save();
        }

        public CommentViewModel GetComment(int id)
        {
            var comment = database.Comments.Get(id);
            return DomainMapper.Mapper.Map<Comment, CommentViewModel>(comment);
        }

        public IEnumerable<CommentViewModel> GetAllComments()
        {
            var comments = database.Comments.GetAll();
            return DomainMapper.Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(comments);
        }

        public void DeleteComment(int id)
        {
            database.Comments.Delete(id);
            database.Save();
        }
    }
}
