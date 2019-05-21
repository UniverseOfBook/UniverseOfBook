using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model {
    public enum ReadWant {
        Read, Want
    }
    public class UserBook {
        public string BookName { get; set; }
        public string Email { get; set; }
        public ReadWant ReadWant { get; set; }
        public DateTime DateTime { get; set; }

    }
}
