using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Razor_pages_non_mvc.Pages
{
    public class IndexModel : PageModel
    { 
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchString)) {
                //...
            }
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
    }
}
