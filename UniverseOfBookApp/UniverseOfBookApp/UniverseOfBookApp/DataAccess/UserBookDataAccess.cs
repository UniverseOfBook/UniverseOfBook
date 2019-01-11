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
   public class UserBookDataAccess
    {
        static SQLiteConnection db;

        public UserBookDataAccess()
        {
            db = DependencyService.Get<SqlConnection>().GetConnection();
            db.CreateTable<UserBook>();
        }

        public List<UserBook> GetAllBook()
        {
            return (from UserBook in db.Table<UserBook>() select UserBook).ToList();
        }
        public UserBook GetBook(int Id)
        {
            return db.Table<UserBook>().FirstOrDefault(i => i.Bookid == Id);
        }
        public UserBook GetBookUser(int Id)
        {
            return db.Table<UserBook>().FirstOrDefault(i => i.Userid == Id);
        }
        
        public void DeleteUserBook(int Id)
        {
            db.Delete<UserBook>(Id);
        }
       
        public void UserInsert(UserBook userBook)
        {
            db.Insert(userBook);
        }
        public void BookUserUpdate(UserBook userBook)
        {
            db.Update(userBook);
        }
    }
}
