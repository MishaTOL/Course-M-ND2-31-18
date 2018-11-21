using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private static int lastId = 1;
        private static List<Post> posts = new List<Post>();
        // GET: api/Post
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return posts;
        }

        // GET: api/Post/5
        [HttpGet("{id}", Name = "Get")]
        public Post Get(int id)
        {
            return posts.FirstOrDefault(x => x.Id == id);
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

            posts.Add(post);
        }
        
        // PUT: api/Post/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string content)
        {
            var post = posts.FirstOrDefault(x => x.Id == id);
            post.Content = content;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            posts.RemoveAll(x => x.Id == id);
        }
    }
}
