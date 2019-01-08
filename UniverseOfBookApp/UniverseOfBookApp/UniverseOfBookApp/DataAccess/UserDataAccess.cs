using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;

namespace UniverseOfBookApp.DataAccess
{
   public class UserDataAccess

    {
        static SQLiteConnection db;
        public const string DBname = "UniverseOfBookApp.db3";

        public UserDataAccess()
        {
            db = DependencyService.Get<SqlConnection>().GetConnection();
            db.CreateTable<User>();
        }

        public List<User> GetAllUsers()
        {
            return (from user in db.Table<User>() select user).ToList();
        }
        public User GetUser(int Id)
        {
            return db.Table<User>().FirstOrDefault(i => i.userId == Id);
        }
        public void DeleteAllUser()
        {
            db.DeleteAll<User>();
        }
        public void DeleteUser(int Id)
        {
            db.Delete<User>(Id);
        }
        public void UserInsert(User user)
        {
            db.Insert(user);
        }
        public void UserUpdate(User user)
        {
            db.Update(user);
        }

        public User Login(string Email,string password)
        {

            return db.Table<User>().FirstOrDefault(x => x.Email == Email && x.Password == password);
            
        }
    }

}
