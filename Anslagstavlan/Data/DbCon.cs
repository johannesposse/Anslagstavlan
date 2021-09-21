using Anslagstavlan.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anslagstavlan.Data
{
    public class DbCon : IdentityDbContext<ChatUserModel>
    {
        public DbCon(DbContextOptions<DbCon> options) :base(options)
        {

        }

        public DbSet<ChatMessageModel> ChatMessageModels { get; set; }
        public DbSet<ChatRoomModel> ChatRoomModels { get; set; }
        public DbSet<ChatUserModel> ChatUserModels { get; set; }

    }
}