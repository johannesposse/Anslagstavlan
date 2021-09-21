﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anslagstavlan.Model
{
    public class ChatUserModel : IdentityUser
    {

        public int ChatUserId { get; set; }
    }
}
