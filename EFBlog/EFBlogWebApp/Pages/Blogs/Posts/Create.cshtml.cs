using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFBlogDataAccessLibrary.DataAccess;
using EFBlogDataAccessLibrary.Models;

namespace EFBlogWebApp.Pages.Blogs.Posts
{
    public class CreateModel : PageModel
    {
        private readonly EFBlogDataAccessLibrary.DataAccess.EFBlogContext _context;

        public CreateModel(EFBlogDataAccessLibrary.DataAccess.EFBlogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BlogId"] = new SelectList(_context.Blogs, "BlogId", "BlogId");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
