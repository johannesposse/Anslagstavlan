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
    [BindProperties]
    public class SignInModel : PageModel
    {
        private readonly SignInManager<ChatUserModel> signInManager;

        public string Username { get; set; }
        public string Password { get; set; }

        public SignInModel(SignInManager<ChatUserModel> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(Username,Password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}
