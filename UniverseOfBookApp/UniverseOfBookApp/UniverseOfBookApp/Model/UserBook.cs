using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model {
    public enum ReadWantEnum {
        Read, Want
    }
    [Table("UserBook")]
    public class UserBook {
        public string BookName { get; set; }
        public string Email { get; set; }
        public ReadWantEnum ReadWant { get; set; }
        public DateTime DateTime { get; set; }

    }
}
