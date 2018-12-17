using RepositoryModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class StudPortalContext : DbContext
    {
        public StudPortalContext() : base("StudPortalDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudPortalContext, Migrations.Configuration>());
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<TagPostMap> TagPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostEntity>()
                .HasRequired(s => s.Author)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommentEntity>()
                .HasRequired(s => s.Author)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommentEntity>()
                .HasRequired(s => s.Post)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
