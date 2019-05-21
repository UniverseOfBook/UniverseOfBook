using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model {
    public enum UserAdmin {
        User, Admin
    }
    public enum GenderEnum {
        Male, Female
    }
    [Table("User")]
    public class User {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        [Unique, NotNull]
        public string UserName { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull, Unique]
        public string Email { get; set; }
        public GenderEnum Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string UserPhoto { get; set; }
        public UserAdmin UserType { get; set; }

    }
}
