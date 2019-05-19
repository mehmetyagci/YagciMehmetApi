using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YagciMehmetApi.Models;

namespace YagciMehmetApi.DB
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=yagcimehmet.db");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}