using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anslagstavlan.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Anslagstavlan.Pages.User
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ChatUserModel> signInManager;

        public LogoutModel(SignInManager<ChatUserModel> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> OnGet()
        {
           await signInManager.SignOutAsync();

           return RedirectToPage("/Index");
        }
    }
}
