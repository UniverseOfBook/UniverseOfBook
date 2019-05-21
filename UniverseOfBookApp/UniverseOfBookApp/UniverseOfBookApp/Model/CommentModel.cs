using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model {

    [Table("CommentModel")]
   public class CommentModel {
     public string bookname { get; set; }
     public string commentOfBook { get; set; }
    }
}
