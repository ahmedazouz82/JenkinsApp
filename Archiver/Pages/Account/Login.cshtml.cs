using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Archiver.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }
        public void OnGet()
        {
            this.Credential = new Credential { UserName = "Admin" };
            //https://youtu.be/ReVJolYLZLU?list=PLgRlicSxjeMOxypAEL2XqIc2m_gPmoVN-
        }

        public async Task<IActionResult> OnPostAsync() // page load
        {
            if (!ModelState.IsValid) return Page();

            if (Credential.UserName == "Admin" && Credential.UserPassword == "pass") {

                var claims = new List<Claim> { 
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Email, "Admin@site.com")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/index");
            }

            return Page();
        }
    }
    public class Credential
    {

        //[Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

    }

}
