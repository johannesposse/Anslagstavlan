using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anslagstavlan.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Anslagstavlan.Pages.ChatRoom
{
    public class DeleteModel : PageModel
    {
        private readonly DbCon dbcon;

        public DeleteModel(DbCon dbcon)
        {
            this.dbcon = dbcon;
        }
        public IActionResult OnGet(int Id)
        {
            var chatroom = dbcon.ChatRoomModels.Where(x => x.ChatRoomId == Id).FirstOrDefault();
            dbcon.Remove(chatroom);

            dbcon.SaveChanges();

            return RedirectToPage("/ChatRoom/Index");
        }
    }
}
