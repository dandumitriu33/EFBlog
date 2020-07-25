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
    public class DeleteModel : PageModel
    {
        private readonly EFBlogDataAccessLibrarySQLServer.DataAccess.EFBlogContextSQLServer _context;

        public DeleteModel(EFBlogDataAccessLibrarySQLServer.DataAccess.EFBlogContextSQLServer context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts
                .Include(p => p.Blog).FirstOrDefaultAsync(m => m.PostId == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts.FindAsync(id);

            if (Post != null)
            {
                _context.Posts.Remove(Post);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
