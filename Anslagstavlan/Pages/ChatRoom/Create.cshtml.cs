using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anslagstavlan.Data;
using Anslagstavlan.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Anslagstavlan.Pages.ChatRoom
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<ChatUserModel> userManager;
        private readonly DbCon dbCon;

        [BindProperty]
        public string ChatRoomName { get; set; }

        public CreateModel(UserManager<ChatUserModel> userManager , DbCon dbCon)
        {
            this.userManager = userManager;
            this.dbCon = dbCon;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() 
        {
            var user = await this.userManager.GetUserAsync(HttpContext.User);
            var chatRoom = new ChatRoomModel { ChatRoomOwner =  user.ChatUserId, ChatRoomName = this.ChatRoomName};
            this.dbCon.Add(chatRoom);
            await dbCon.SaveChangesAsync();
            return RedirectToPage("/Chatroom/viewchat", new { id = chatRoom.ChatRoomId});

        }
    }
}
