using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Lab2.Data.Contracts;

namespace Lab2.Data.Implementation
{
    class DBLab2Context : DbContext
    {
        public DBLab2Context() :
            base("name=DBLab2")
        { }
        public IDbSet<StudentEntity> Students { get; set; }
        public IDbSet<PostEntity> Posts { get; set; }
        public IDbSet<CommentEntity> Comments { get; set; }
        public IDbSet<TagEntity> Tags { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>()
                .HasMany(t => t.Posts)
                .WithRequired(t => t.Author)
                .HasForeignKey(t => t.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentEntity>()
                .HasMany(t => t.Comments)
                .WithRequired(t => t.Author)
                .HasForeignKey(t => t.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostEntity>()
                .HasMany(t => t.Comments)
                .WithRequired(t => t.Post)
                .HasForeignKey(t => t.PostId)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<PostEntity>()
                .HasMany(t => t.Tags)
                .WithMany(t => t.Posts)
                .Map(t => t
                    .MapRightKey("TagId")
                    .MapLeftKey("PostId")
                    .ToTable("TagPost"));


            base.OnModelCreating(modelBuilder);
        }
    }
}
