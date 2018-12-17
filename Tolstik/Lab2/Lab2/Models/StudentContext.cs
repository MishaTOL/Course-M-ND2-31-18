using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CurrentStudent> CurrentStudent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasMany(c => c.Tags)
                .WithMany(s => s.Posts)
                .Map(t => t.MapLeftKey("PostId")
                .MapRightKey("TagId")
                .ToTable("PostTag"));
        }
    }
}