using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model {
    public enum UserAdmin {
        User, Admin
    }
    public enum Gender {
        Male, Female
    }
    [Table("User")]
    public class UserClass {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        [Unique, NotNull]
        public string UserName { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull, Unique]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Phonenumber { get; set; }
        public string Name { get; set; }
        public string UserPhoto { get; set; }
        public UserAdmin Useradmin { get; set; }

    }
}
