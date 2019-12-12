using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages.Account
{
    [AllowAnonymous]
    public class LogoutRequesterModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync() 
        {
            Console.WriteLine("Posting logout..");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return LocalRedirect(Url.Content("~/"));
        }
        public void OnGet()
        {
        }
    }
}
