using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.Model
{
    [Table("UserFriends")]
   public class UserFriends
    {
        public string UserEmail { get; set; }
        public string FriendEmail { get; set; }

    }
}
