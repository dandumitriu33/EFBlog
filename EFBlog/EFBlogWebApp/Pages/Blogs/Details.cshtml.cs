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
    public class DetailsModel : PageModel
    {
        private readonly EFBlogDataAccessLibrary.DataAccess.EFBlogContext _context;

        public DetailsModel(EFBlogDataAccessLibrary.DataAccess.EFBlogContext context)
        {
            _context = context;
        }

        public Blog Blog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blogs.FirstOrDefaultAsync(m => m.BlogId == id);

            if (Blog == null)
            {
                return NotFound();
            }

            var posts = _context.Posts.Where(p => p.BlogId == Blog.BlogId).ToList();
            Blog.Posts = posts;
            return Page();

            
        }
    }
}
