﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFBlogDataAccessLibrary.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
    }
}
