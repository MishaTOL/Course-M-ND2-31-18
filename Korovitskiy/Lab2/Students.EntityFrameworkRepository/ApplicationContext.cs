using Students.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.EntityFrameworkRepository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationContext>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var student = modelBuilder.Entity<Student>();
            student.HasKey(s => s.Id);
            student.Property(s => s.FirstName).IsRequired().IsUnicode();
            student.Property(s => s.LastName).IsRequired().IsUnicode();

            var post = modelBuilder.Entity<Post>();
            post.Property(p => p.Content).IsRequired().IsUnicode();
            post.Property(p => p.CreatedDate).IsRequired();
            post.HasRequired(p => p.Author).WithMany(s => s.Posts)
                .HasForeignKey(k=>k.StudentId).WillCascadeOnDelete(false); ;

            var comment = modelBuilder.Entity<Comment>();
            comment.Property(c => c.CreatedDate).IsRequired();
            comment.Property(c => c.Content).IsRequired().IsUnicode();
            comment.HasRequired(c => c.Author).WithMany(s => s.Comments)
                .HasForeignKey(k=>k.StudentId);
            comment.HasRequired(c => c.Post).WithMany(p => p.Comments)
                .HasForeignKey(k=>k.PostId);

            var tag = modelBuilder.Entity<Tag>();
            tag.Property(t => t.Name).IsRequired();
            tag.HasMany(t => t.Posts).WithMany(p => p.Tags).Map(tp =>
            {
                tp.ToTable("PostTag");
                tp.MapLeftKey("TagId");
                tp.MapRightKey("PostId");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
