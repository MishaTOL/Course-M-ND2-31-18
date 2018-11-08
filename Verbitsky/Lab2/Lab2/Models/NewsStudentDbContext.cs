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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(a => a.Posts)
                .WithRequired(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<Student>().
                HasMany(a => a.Comments)
                .WithRequired(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tags>()
                .HasMany(a => a.Posts)
                .WithMany(a => a.Tags)
                .Map(a =>
                {
                    a.MapLeftKey("Tags_Id");
                    a.MapRightKey("Posts_Id");
                    a.ToTable("TagsPosts");
                });
        }
    }
}