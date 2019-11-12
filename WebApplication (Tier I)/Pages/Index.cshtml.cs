using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Razor_pages_non_mvc.Pages
{
    public class IndexModel : PageModel
    { 
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                OnPostSearch();
            }
        }
        public RedirectToPageResult OnPostSearch()
        {
            return RedirectToPage("Products", SearchString);
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
    }
}
