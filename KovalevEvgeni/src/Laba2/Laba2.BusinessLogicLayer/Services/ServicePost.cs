using AutoMapper;
using Laba2.BusinessLogicLayer.DataTransferObject;
using Laba2.BusinessLogicLayer.Interfaces;
using Laba2.DataAccessLayer.Entity;
using Laba2.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.BusinessLogicLayer.Services
{
    public class ServicePost : IServicePost
    {
        private IUnitOfWork database;
        private IMapper mapper;
        public ServicePost(IUnitOfWork database)
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>()
                .ForMember(post => post.Author, map => map.MapFrom(item => $"{item.Student.FirstName} {item.Student.LastName}")).ForMember(post => post.Tags, map => map.MapFrom(item => MapTagsDto(item)));
                cfg.CreateMap<PostDTO, Post>().ForMember(post => post.Tags, map => map.MapFrom(item => MapTags(item.Tags)));
            }
            ).CreateMapper();
            this.database = database;
        }

        private string MapTagsDto(Post item)
        {
            StringBuilder result = new StringBuilder();
            foreach (var itemTag in item.Tags)
            {
                result.Append($" {itemTag.Details},");
            }
            return result.ToString().TrimStart(' ').TrimEnd(',');
        }

        private IEnumerable<Tag> MapTags(string item)
        {
            char[] split = { ',' };
            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;
            string[] mas = item.Split(split, options);
            List<Tag> result = new List<Tag>();
            foreach (var details in mas)
            {
                result.Add(new Tag { Details = details.Trim() });
            }
            return result;
        }

        public void Delete(int postId)
        {
            database.Posts.Delete(postId);
            database.Save();
        }

        public PostDTO GetPost(int postId)
        {
            return mapper.Map<Post, PostDTO>(database.Posts.GetRecord(postId));
        }

        public IEnumerable<PostDTO> GetPostes(int studentId)
        {
            IEnumerable<PostDTO> listPost = mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(database.Posts.GetAll());
            foreach (PostDTO item in listPost)
            {
                if (item.StudentId == studentId)
                {
                    item.OperationRecord = true;
                }
            }
            return listPost;
        }

        public void Insert(PostDTO record)
        {
            record.DateCreate = DateTime.Now;
            Post post = mapper.Map<PostDTO, Post>(record);
            post.Tags=OperationInsertTag(post);
            database.Posts.Create(post);
            database.Save();
        }

        public void Update(PostDTO record)
        {
            Post post = mapper.Map<PostDTO, Post>(record);
            Post postEdit = database.Posts.GetRecord(post.PostId);
            postEdit.Tags.Clear();
            postEdit.Content = post.Content;
            foreach (Tag itemTag in post.Tags)
            {
                Tag tag = database.Tags.Find(x => x.Details == itemTag.Details).FirstOrDefault();
                if (tag == null)
                {
                    database.Tags.Create(itemTag);
                    postEdit.Tags.Add(itemTag);
                }
                else
                    postEdit.Tags.Add(tag);
            }
            database.Save();
            database.Posts.Update(postEdit);
            database.Save();
        }

        private List<Tag> OperationInsertTag(Post post)
        {
            List<Tag> result = new List<Tag>();
            foreach (Tag itemTag in post.Tags)
            {
                Tag tag = database.Tags.Find(x => x.Details == itemTag.Details).FirstOrDefault();
                if (tag == null)
                {
                    database.Tags.Create(itemTag);
                    result.Add(itemTag);
                }
                else
                    result.Add(tag);
            }
            database.Save();
            return result;
        }

        private void OperationRemoveTag(Post post)
        {
            foreach (Tag itemTag in post.Tags)
            {
                database.Tags.Delete(itemTag.TagId);
                database.Save();
            }
        }
    }
}
