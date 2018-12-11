using Jwt.Api.Controllers;
using Jwt.Api.Models;
using Microsoft.AspNet.SignalR;

namespace Jwt.Api.Hubs
{
    public class PostHub : Hub
    {
        private static int lastId = 1;

        public void createPost(string content)
        {
            var post = new Post {
                Id = lastId++,
                Content = content
            };
            PostStorage.Posts.Add(post);

            Clients.Others.addPost(post.Id, post.Content);
        }
    }
}
