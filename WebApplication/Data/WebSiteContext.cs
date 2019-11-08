using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace Razor_pages_non_mvc.Data
{
    public class WebSiteContext : DbContext
    {
        public WebSiteContext (DbContextOptions<WebSiteContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }
    }
}
