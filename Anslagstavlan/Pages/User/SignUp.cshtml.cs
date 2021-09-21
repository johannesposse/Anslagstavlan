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
    public class SignUpModel : PageModel
    {
        private readonly UserManager<ChatUserModel> userManager;
        private readonly SignInManager<ChatUserModel> signInManager;

        public string Username { get; set; }
        public string Password { get; set; }

        public SignUpModel(UserManager<ChatUserModel> userManager, SignInManager<ChatUserModel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ChatUserModel { UserName = this.Username };
                var result = await userManager.CreateAsync(user, this.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToPage("/Index");
                }
            }

            return Page();
        }
    }
}
