using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_pages_non_mvc.Pages
{
    public class TimeModel : PageModel
    {
        public string message;
        public void OnGet()
        {
            message = "Message from model";
        }
        public string Says(string mess)
        {
            return "Model says " + mess;
        }
    }
}
