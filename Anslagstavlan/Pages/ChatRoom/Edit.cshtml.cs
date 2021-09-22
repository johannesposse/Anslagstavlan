using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anslagstavlan.Data;
using Anslagstavlan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Anslagstavlan.Pages.ChatRoom
{
    public class EditModel : PageModel
    {
        private readonly DbCon dbCon;

        public ChatRoomModel ChatRoom { get; set; }

        public EditModel(DbCon dbCon)
        {
            this.dbCon = dbCon;
        }
        public void OnGet(int Id)
        {
            var chatRoom = dbCon.ChatRoomModels.Where(x => x.ChatRoomId == Id).FirstOrDefault();
            chatRoom = this.ChatRoom;
        }

        public void OnPost()
        {

        }
    }
}
