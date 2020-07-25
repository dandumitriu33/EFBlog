using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFBlogDataAccessLibrary.DataAccess;
using EFBlogDataAccessLibrary.Models;

namespace EFBlogWebApp.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly EFBlogDataAccessLibrary.DataAccess.EFBlogContext _context;

        public IndexModel(EFBlogDataAccessLibrary.DataAccess.EFBlogContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get;set; }

        public async Task OnGetAsync()
        {
            Blog = await _context.Blogs.ToListAsync();
        }
    }
}
