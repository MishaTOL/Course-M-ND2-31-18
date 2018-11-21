using Laba2.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.DataAccessLayer.EF
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public StudentDbContext() : base("StudentDbContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Post>()
                        .HasMany<Tag>(s => s.Tags)
                        .WithMany(c => c.Posts)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("Tag_TagId");
                            cs.MapRightKey("Post_PostId");
                            cs.ToTable("TagPosts");
                        });

        }

    }
}
