using EFBlogDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFBlogDataAccessLibrary.DataAccess
{
    public class EFBlogContext : DbContext
    {
        public EFBlogContext(DbContextOptions options) : base (options) { }
        
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source = blogging.db");

    }
}
