using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lab2.Models
{
    public class NewsStudentDbContext : DbContext
    {
        public NewsStudentDbContext() :base("name=NewsStudent")
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TagsPosts> TagsPosts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().
                HasMany(a => a.Posts).
                WithRequired(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<Student>().
                HasMany(a => a.Comments).
                WithRequired(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TagsPosts>()
                .HasKey(a => new { a.IdTag, a.IdPost });

            modelBuilder.Entity<Tags>()
                .HasMany(a => a.TagsPosts)
                .WithRequired()
                .HasForeignKey(a => a.IdTag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(a => a.TagsPosts)
                .WithRequired()
                .HasForeignKey(a => a.IdPost)
                .WillCascadeOnDelete(false);
        }
    }
}