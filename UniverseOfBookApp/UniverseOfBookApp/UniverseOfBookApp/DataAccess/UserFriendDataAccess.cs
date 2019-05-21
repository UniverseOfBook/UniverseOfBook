using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;

namespace UniverseOfBookApp.DataAccess {
    public class UserFriendDataAccess {
        static SQLiteConnection db;
        public UserFriendDataAccess() {
            db = DependencyService.Get<ISqlConnection>().GetConnection();
            db.CreateTable<UserFriends>();
        }
        public List<UserFriends> GetAllFriends(string email) {
            return (from users in db.Table<UserFriends>() where users.UserEmail == email select users).ToList();
        }
        public UserFriends GetUser(string email, string FriendEmail1) {
            return db.Table<UserFriends>().FirstOrDefault(x => x.UserEmail == email && x.FriendEmail == FriendEmail1);
        }
        public int Insert(UserFriends userFriends) {
            return db.Insert(userFriends);
        }
        public int countFriends(string Email) {
            List<UserFriends> userFriends = (from users in db.Table < UserFriends >() where users.UserEmail == Email select users).ToList();
            return userFriends.Count;
        }
        public int DeleteUserFriends(string Email) {
            return db.Table<UserFriends>().Delete(x => x.FriendEmail == Email);
        }
    }
}
