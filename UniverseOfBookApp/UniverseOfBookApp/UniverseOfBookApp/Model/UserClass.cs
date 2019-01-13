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
   public class UserClass
    { 
        [PrimaryKey,AutoIncrement]
        public int userId { get; set; }
        [Unique,NotNull]
        public string UserName { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull,Unique]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string phonenumber { get; set; }
        public string Name { get; set; }
        public string UserPhoto { get; set; }
        public UserAdmin useradmin { get; set; }

    }

    
}
