using Data.Contracts.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Repositories.EntityFramework
{
    public class StudentContext : DbContext
    {
        static StudentContext()
        {
            Database.SetInitializer<StudentContext>(new StudentDbInitializer());
        }

        public StudentContext()
            : base("StudentDB")
        {
        }

        public StudentContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Comment>()
                .Property(x => x.Content)
                .IsRequired()
                .IsUnicode();
            modelBuilder.Entity<Comment>()
                .Property(x => x.Created)
                .IsRequired();
            modelBuilder.Entity<Post>().Property(x => x.Title)
                .IsRequired()
                .IsUnicode();
            modelBuilder.Entity<Post>()
                .Property(x => x.Content)
                .IsRequired()
                .IsUnicode();
            modelBuilder.Entity<Post>()
                .Property(x => x.Created)
                .IsRequired();
            modelBuilder.Entity<Student>()
                .Property(x => x.FirstName)
                .IsRequired()
                .IsUnicode();
            modelBuilder.Entity<Student>()
                .Property(x => x.LastName)
                .IsRequired()
                .IsUnicode();
            modelBuilder.Entity<Tag>()
                .Property(x => x.Name)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Posts)
                .WithRequired(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Post)
                .HasForeignKey(x => x.PostId);
            modelBuilder.Entity<Post>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Posts);

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Tag> Tags { get; set; }
    }
}
