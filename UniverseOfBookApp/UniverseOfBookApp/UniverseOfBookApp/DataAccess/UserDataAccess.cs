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
       

        public UserDataAccess()
        {
            db = DependencyService.Get<SqlConnection>().GetConnection();
            db.CreateTable<UserClass>();
        }

        public List<UserClass> GetAllUsers()
        {
            return (from user in db.Table<UserClass>() where user.useradmin==UserAdmin.User select user ).ToList();
        }
        public UserClass GetUser(int Id)
        {
            return db.Table<UserClass>().FirstOrDefault(i => i.userId == Id);
        }
        public UserClass GetUserByEmail(string email) {
            return db.Table<UserClass>().FirstOrDefault(i => i.Email == email);
        }
        public void DeleteAllUser()
        {
            //List<User> users = new List<User>();
            //users = GetAllUsers();
            //db.DeleteAll<User>();
            db.Table<UserClass>().Delete(x => x.useradmin == UserAdmin.User);
        }
        public int DeleteUserName (String UserName)
        {
            return db.Table<UserClass>().Delete(x => x.UserName == UserName);
        }
        public void DeleteUser(int Id)
        {
            db.Delete<UserClass>(Id);
        }
        public int UserInsert(UserClass user)
        {
          return  db.Insert(user);
        }
        public void UserUpdate(UserClass user)
        {
            db.Update(user);
        }

        public UserClass Login(string Email,string password)
        {

            return db.Table<UserClass>().FirstOrDefault(x => x.Email == Email && x.Password == password);
            
        }
    }

}
