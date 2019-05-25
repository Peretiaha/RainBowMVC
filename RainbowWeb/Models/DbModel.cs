using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RainbowWeb.Models
{
    public class DbModel : DbContext
    {

        public DbModel() : base("RainBowDb")
        {

        }

        public DbSet<LoginUser> LoginUsers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Commands> Commands { get; set; }
        public DbSet<Contacts> Contacts { get; set; }


    }
}