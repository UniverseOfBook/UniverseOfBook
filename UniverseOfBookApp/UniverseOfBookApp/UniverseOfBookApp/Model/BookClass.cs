using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace UniverseOfBookApp.Model
{
    public enum CategoryEnum
    {
        Crime,Dram, Biographies, History, Sport, Education, Kids, Cooking, Horror, Medical, Religion, Romance, ModernClassic,Psychology, ScienceFiction, SuspenseFiction, Fantastic
    }
    public enum Publishers
    {
        Can,Iletisim,IsBankası,YapıKredi,Domingo,Ithaki
    }
    [Table("Book")]
    public class BookClass 
    {
        [NotNull,MaxLength(30),Unique]
        public string BookName { get; set; }
        public DateTime PublishDate { get; set; }
        public Publishers Publishers { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public string AuthorName { get; set; }
        public CategoryEnum Category { get; set; }
        public string bookphoto { get; set; }
        
        
    }
}
