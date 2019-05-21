﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace UniverseOfBookApp.Model {
    public enum CategoryEnum {
        Crime, Dram, Biographies, History, Sport, Education, Kids, Cooking, Horror, Medical, Religion, Romance, ModernClassic, Psychology, ScienceFiction, SuspenseFiction, Fantastic
    }
    public enum PublishersEnum {
        Can, Iletisim, IsBankasi, YapiKredi, Domingo, Ithaki
    }
    [Table("Book")]
    public class Book {
        [NotNull, MaxLength(30), Unique]
        public string BookName { get; set; }
        public DateTime PublishDate { get; set; }
        public PublishersEnum Publishers { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public string AuthorName { get; set; }
        public CategoryEnum Category { get; set; }
        public string BookPhoto { get; set; }

    }
}
