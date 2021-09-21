﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anslagstavlan.Model
{
    public class ChatRoomModel
    {
        [Key]
        public int ChatRoomId { get; set; }
        public int ChatRoomOwner { get; set; } // A ChatUserModel id
        public string ChatRoomName { get; set; }
        public List<ChatMessageModel> Messages { get; set; }
    }
}
