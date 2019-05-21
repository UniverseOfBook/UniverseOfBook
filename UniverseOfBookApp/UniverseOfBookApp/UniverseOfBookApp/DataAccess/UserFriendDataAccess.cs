using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;

namespace UniverseOfBookApp.DataAccess
{
     public  class UserFriendDataAccess
     {
        static SQLiteConnection db;
        public UserFriendDataAccess()
        {
            db = DependencyService.Get<SqlConnection>().GetConnection();
            db.CreateTable<UserFriends>();
        }
        public List<UserFriends> GetAllFriends(string email)
        {
            return (from users in db.Table<UserFriends>() where users.UserEmail == email select users).ToList();
        }
        public UserFriends getUser(string email,string FriendEmail1) {


            return db.Table<UserFriends>().FirstOrDefault(x => x.UserEmail == email && x.FriendEmail == FriendEmail1);
        }
        public int Insert(UserFriends userFriends)
        {
            return db.Insert(userFriends);
        }
        public int DeleteUserFriends(string Email)
        {
            return db.Table<UserFriends>().Delete(x => x.FriendEmail == Email);
        }
    }
}
