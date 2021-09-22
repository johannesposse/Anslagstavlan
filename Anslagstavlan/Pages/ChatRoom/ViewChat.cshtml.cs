using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anslagstavlan.Data;
using Anslagstavlan.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Anslagstavlan.Pages.ChatRoom
{
    public class ViewChatModel : PageModel
    {
        private readonly DbCon dbCon;

        public ChatRoomModel ChatRoom { get; set; }

        [BindProperty]
        public ChatMessageModel Messages { get; set; }

        public List<ChatMessageModel> MessagesList { get; set; } = new List<ChatMessageModel>();
        public UserManager<ChatUserModel> UserManager { get; }

        public static int staticID { get; set; }

        public ViewChatModel(DbCon dbCon, UserManager<ChatUserModel> userManager)
        {
            this.dbCon = dbCon;
            UserManager = userManager;
        }
        public async Task OnGet(int Id)
        {
            staticID = Id;
            var user = await UserManager.GetUserAsync(HttpContext.User);

            ChatRoom = dbCon.ChatRoomModels.FirstOrDefault(x => x.ChatRoomId == Id);

            MessagesList = dbCon.ChatMessageModels.Include(x => x.ChatUser).Where(x => x.ChatRoomId == Id).ToList();

        }

        public async Task<IActionResult> OnPost()
        {

            var user = await UserManager.GetUserAsync(HttpContext.User);
            ChatRoom = dbCon.ChatRoomModels.FirstOrDefault(x => x.ChatRoomId == staticID);

            Messages.Date = DateTime.Now;
            Messages.ChatRoomId = ChatRoom.ChatRoomId;
            Messages.ChatUser = user;
            Messages.ChatUserId = user.ChatUserId;
            Messages.ChatRoom = ChatRoom;

            dbCon.Add(Messages);
            await dbCon.SaveChangesAsync();

            return RedirectToPage("/ChatRoom/ViewChat", new { Id = ChatRoom.ChatRoomId});
        }
    }
}
