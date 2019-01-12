using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace UniverseOfBookApp.Model
{
    public enum CategoryEnum
    {
        Crime,Dram, Biographies, History, Sport, Education, Kids, Cooking, Horror, Medical, Religion, Romance, ModernClassic,Psychology, ScieneFiction, Suspensefiction
    }
    public enum Publishers
    {
        Can,Iletisim,IsBankası,YapıKredi,Domingo
    }
    [Table("Book")]
    public class BookClass 
    {
        [PrimaryKey,AutoIncrement]
        public int BookID { get; set; }
        [NotNull,MaxLength(30),Unique]
        public string BookName { get; set; }
        public DateTime PublishDate { get; set; }
        public Publishers Publishers { get; set; }
        public int PageNumber { get; set; }
        public string AuthorName { get; set; }
        public CategoryEnum Category { get; set; }
        public string bookphoto { get; set; }
        
        
    }
}
