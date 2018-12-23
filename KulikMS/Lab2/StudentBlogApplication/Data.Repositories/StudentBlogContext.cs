using Data.Contracts.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Data.Repositories
{
    public class StudentBlogContext : DbContext
    {
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Tag> Tags { get; set; }

        public StudentBlogContext() : base("name=StudentBlogContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var post = modelBuilder.Entity<Post>();
            post.Property(b => b.Created)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            post.HasRequired(s => s.Author)
                .WithMany(p => p.Posts)
                .HasForeignKey(s => s.AuthorId)
                .WillCascadeOnDelete(false);
            post.HasMany(s => s.Tags)
                .WithMany(p => p.Posts)
                .Map(cs =>
                {
                    cs.MapLeftKey("PostId");
                    cs.MapRightKey("TagId");
                    cs.ToTable("PostTag");
                });

            var comment = modelBuilder.Entity<Comment>();
            comment.Property(b => b.Created)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            comment.HasRequired(s => s.Author)
                .WithMany(p => p.Comments)
                .HasForeignKey(s => s.AuthorId)
                .WillCascadeOnDelete(false);
            comment.HasRequired(s => s.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(s => s.PostId)
                .WillCascadeOnDelete(false);
        }
    }
}
