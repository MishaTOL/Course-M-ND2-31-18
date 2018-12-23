using Lab2.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }
        public DbSet<Postdb> Posts { get; set; }

        public DbSet<Tagdb> Tags { get; set; }
        public DbSet<Studentdb> Students { get; set; }
        public DbSet<Commentdb> Comments { get; set; }


    }
}