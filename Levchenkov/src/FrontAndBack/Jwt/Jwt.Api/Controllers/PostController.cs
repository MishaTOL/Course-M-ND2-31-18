using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Api.Controllers
{
    public class PostStorage
    {
        public static List<Post> Posts = new List<Post>();
    }

    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private static int lastId = 1;
        // GET: api/Post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return PostStorage.Posts;
        }

        // GET: api/Post/5
        [HttpGet("{id}", Name = "Get")]
        public Post Get(int id)
        {
            return PostStorage.Posts.FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Post
        [HttpPost]
        public void Post(string content)
        {
            var post = new Post
            {
                Id = lastId++,
                Content = content
            };

            PostStorage.Posts.Add(post);
        }
        
        // PUT: api/Post/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string content)
        {
            var post = PostStorage.Posts.FirstOrDefault(x => x.Id == id);
            post.Content = content;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PostStorage.Posts.RemoveAll(x => x.Id == id);
        }
    }
}
