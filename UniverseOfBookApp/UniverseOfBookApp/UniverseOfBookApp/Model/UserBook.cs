using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model
{
    public enum ReadWant
    {
        Read,Want
    }
   public class UserBook
    {
        public string BookName { get; set; }
        public string UserName { get; set; }
        public ReadWant ReadWant { get; set; }

    }
}
