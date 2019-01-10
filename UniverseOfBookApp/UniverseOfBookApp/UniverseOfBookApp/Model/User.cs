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
    public enum Gender
    {
        Male,Female
    }
    [Table("User")]
   public class User
    { 
        [PrimaryKey,AutoIncrement]
        public int userId { get; set; }
        public string UserName { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public int phonenumber { get; set; }
        public string Name { get; set; }
        
        public UserAdmin UserAdmin { get; set; }

    }

    
}
