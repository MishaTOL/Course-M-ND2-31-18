using DBModels.Models;
using System.Data.Entity;


namespace DBRepConUow.Context
{
    public class ForumContext: DbContext
    {
        public ForumContext() : base("ForumDBContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ForumContext>());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                    .HasMany(c => c.Comments)
                    .WithRequired(o => o.Post)
                    .HasForeignKey(o => o.PostId)
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>()
                    .HasMany(c => c.Posts)
                    .WithRequired(o => o.Student)
                    .HasForeignKey(o => o.StudentId)
                    .WillCascadeOnDelete(false);
        }
    }
}
