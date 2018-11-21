using Lab2.Business.Abstraction;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Business.Abstraction.Entity;
using Lab2.DataAccess.Abstraction;
using PostContract = Labs2.DataAccess.Entity.Post;

namespace Lab2.Business.Service
{
    public class PostService : IPostService
    {
        private readonly IContextFactory contextFactory;

        public PostService(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public void AddPost(Post post, int studentId)
        {
            using (var context = contextFactory.GetContext())
            {
                var student = context.StudentsRepository.Where(m => m.Id == studentId).FirstOrDefault();
                context.Add(context.PostsRepository, new PostContract()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content =post.Content,
                    Created =DateTime.Now,
                    Author= student
                });

                context.Save();
            }
            
        }
        public List<Post> GetPosts(int studentId)
        {
            using (var context = contextFactory.GetContext())
            {
                var result = context.PostsRepository.Where(x => x.StudentId == studentId)
                    .Join(context.StudentsRepository, p => p.StudentId, x => x.Id, (p, x) => new Post()
                    {
                         Author = new Student() { Id = x.Id, FirstName= x.FirstName, LastName=x.LastName},
                         Id= p.Id,
                         Content= p.Content,
                         Created = p.Created,
                         Title = p.Title                        
                    }).ToList();
       
                return result;
            }
        }

          public int DeletePost(int id)
        {
            int studentId=0;
            using (var context = contextFactory.GetContext())
            {
                var post = context.PostsRepository.FirstOrDefault(m => m.Id == id);
                var comments = context.CommentsRepository.Where(x => x.PostId == id).ToList();
                var tags = context.TagsRepository.Where(x => x.Posts.FirstOrDefault().Id == id).ToList();
                
                if (post != null)
                {
                    foreach (var item in tags)
                    {
                        post.Tags.Remove(item);
                    }
                    foreach (var item in comments)
                    {
                        context.Delete(context.CommentsRepository, item);
                    }
                    studentId = post.StudentId;
                    context.Delete(context.PostsRepository, post);
                    context.Save();
                }
                return studentId;
            }
        }

        public void UpdatePost(Post post)
        {
            using (var context = contextFactory.GetContext())
            {
                var updatePost = context.PostsRepository.FirstOrDefault(m => m.Id==post.Id);

                if (updatePost != null)
                {
                    updatePost.Content = post.Content;
                    updatePost.Created = DateTime.Now;
                    updatePost.Title = post.Title;
                    context.Save();
                }
            }
        }

        public Post FindPost(int id)
        {
            using (var context = contextFactory.GetContext())
            {
                var findedPost = context.PostsRepository.Where(m => m.Id == id)
                    .Join(context.StudentsRepository, p => p.StudentId, x => x.Id, (p, x) => new Post()
                {
                    Id = p.Id,
                    Author= new Student() { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName },
                    Content= p.Content,
                    Created= p.Created,
                    Title = p.Title                     
                }).FirstOrDefault();

                return findedPost;
            }
        }

    }
}
