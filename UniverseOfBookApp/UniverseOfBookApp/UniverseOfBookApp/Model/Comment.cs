using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model {

    [Table("Comment")]
    public class Comment {
        public string Bookname { get; set; }
        public string CommentOfBook { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }
    }
}
