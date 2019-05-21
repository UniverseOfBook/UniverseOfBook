using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;

namespace UniverseOfBookApp.DataAccess {
    public class UserDataAccess {
        static SQLiteConnection db;

        public UserDataAccess() {
            db = DependencyService.Get<ISqlConnection>().GetConnection();
            db.CreateTable<User>();
        }
        public List<User> GetAllUsers() {
            return (from user in db.Table<User>() where user.UserType == UserAdmin.User select user).ToList();
        }
        public User GetUserByEmail(string email) {
            return db.Table<User>().FirstOrDefault(i => i.Email == email);
        }
        public void DeleteAllUser() {
            db.Table<User>().Delete(x => x.UserType == UserAdmin.User);
        }
        public int DeleteUserName(String UserName) {
            return db.Table<User>().Delete(x => x.UserName == UserName);
        }
        public int AddUser(User user) {
            return db.Insert(user);
        }
        public void UpdateUser(User user) {
            db.Update(user);
        }
        public User Login(string Email, string password) {
            return db.Table<User>().FirstOrDefault(x => x.Email == Email && x.Password == password);
        }
    }
}
