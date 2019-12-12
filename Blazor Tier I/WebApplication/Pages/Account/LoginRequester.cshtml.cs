using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages.Account
{
    [AllowAnonymous]
    public class LoginRequestModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            Console.WriteLine("Posting here..");
            // TODO get claims here by username from database.
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, username),
                new Claim("Role", "admin")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return LocalRedirect(Url.Content("~/"));
        }
    }
}
