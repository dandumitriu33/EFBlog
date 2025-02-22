﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFBlogDataAccessLibrarySQLServer.DataAccess;
using EFBlogDataAccessLibrarySQLServer.Models;

namespace EFBlogWebApp.Pages.Blogs.Posts
{
    public class CreateModel : PageModel
    {
        private readonly EFBlogDataAccessLibrarySQLServer.DataAccess.EFBlogContextSQLServer _context;

        public CreateModel(EFBlogDataAccessLibrarySQLServer.DataAccess.EFBlogContextSQLServer context)
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
