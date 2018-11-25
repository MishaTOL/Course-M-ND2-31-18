using Data.Contracts.Models;
using Data.Implementation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data.Implementation.Models
{
    public class TweetRepository
    {
        private readonly ApplicationDbContext context;
        public TweetRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(TweetEntity tweet)
        {
            context.Tweets.Add(tweet);
            context.SaveChanges();
        }
        public IEnumerable<TweetEntity> Read()
        {
            return context.Tweets.ToList();
        }
        public TweetEntity Read(int id)
        {
            return context.Tweets.Find(id);
        }
        public void Update(TweetEntity tweet)
        {
            context.Tweets.Attach(tweet);
            var entry = context.Entry(tweet);
            entry.Property(a => a.Head).IsModified = true;
            entry.Property(a => a.Content).IsModified = true;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var oldEntity = new TweetEntity { Id = id };
            context.Tweets.Attach(oldEntity);
            context.Tweets.Remove(oldEntity);
            context.SaveChanges();
        }
    }
}
