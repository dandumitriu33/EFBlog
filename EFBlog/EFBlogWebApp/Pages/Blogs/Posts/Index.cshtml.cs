using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFBlogDataAccessLibrarySQLServer.DataAccess;
using EFBlogDataAccessLibrarySQLServer.Models;

namespace EFBlogWebApp.Pages.Blogs.Posts
{
    public class IndexModel : PageModel
    {
        private readonly EFBlogDataAccessLibrarySQLServer.DataAccess.EFBlogContextSQLServer _context;

        public IndexModel(EFBlogDataAccessLibrarySQLServer.DataAccess.EFBlogContextSQLServer context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Posts
                .Include(p => p.Blog).ToListAsync();
        }
    }
}
