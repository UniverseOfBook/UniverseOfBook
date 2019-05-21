using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model {
    [Table("Author")]
    public class AuthorClass {
        [NotNull, Unique]
        public string AuthorName { get; set; }
        public DateTime AuthorDate { get; set; }
        public string AuthorPhoto { get; set; }
        public string AuthorDescription { get; set; }

    }
}
