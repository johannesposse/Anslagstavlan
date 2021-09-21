using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anslagstavlan.Data;
using Anslagstavlan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Anslagstavlan.Pages.ChatRoom
{
    public class IndexModel : PageModel
    {
        private readonly DbCon dbcon;

        public List<ChatRoomModel> chatRooms { get; set; } = new List<ChatRoomModel>();

        public IndexModel(DbCon dbcon)
        {
            this.dbcon = dbcon;
        }
        public async Task OnGet()
        {
            if (dbcon.ChatRoomModels.Any())
            {
                chatRooms = await dbcon.ChatRoomModels.ToListAsync();
            }
        }
    }
}
