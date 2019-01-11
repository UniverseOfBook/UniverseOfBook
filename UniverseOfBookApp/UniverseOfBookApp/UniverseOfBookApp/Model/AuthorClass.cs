using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model
{
    [Table("Author")]
   public class AuthorClass
    {
        [PrimaryKey,AutoIncrement]
        public int AuthorID { get; set; }
        [NotNull,Unique]
        public string AuthorName { get; set; }
        public DateTime AuthorDate { get; set; }
        public string AuthorPhoto { get; set; }
        public string AuthorDescription { get; set; }

    }
}
