using EFBlogDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFBlogDataAccessLibrary.DataAccess
{
    public interface IEFBlogContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Post> Posts { get; set; }
    }
}