using Lab2.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Context
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection") { }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Tags> Tags { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<Lab2.MyService.Infrastructure.ViewCRUD.ViewPost> ViewPosts { get; set; }
    }
}