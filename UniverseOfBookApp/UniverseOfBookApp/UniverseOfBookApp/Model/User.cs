using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model
{
    public enum UserAdmin
    {
        User,Admin
    }
   public class User
    { 
        [PrimaryKey,AutoIncrement]
        public int userId { get; set; }
        public string UserName { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull]
        public string Email { get; set; }
        public UserAdmin UserAdmin { get; set; }

    }

    
}
