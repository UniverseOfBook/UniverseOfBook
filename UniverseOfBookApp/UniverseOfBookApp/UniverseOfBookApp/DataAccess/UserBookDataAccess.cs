using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;

namespace UniverseOfBookApp.DataAccess {
    public class UserBookDataAccess {
        static SQLiteConnection db;

        public UserBookDataAccess() {
            db = DependencyService.Get<SqlConnection>().GetConnection();
            db.CreateTable<UserBook>();
        }
       
     
        public int GetUserReadorWantCountBook(string Email, ReadWantEnum readWant) {
            List<UserBook> userBooks = (from book in db.Table<UserBook>() where book.Email == Email && book.ReadWant == readWant select book).ToList();
            return userBooks.Count;
        }
        public List<String> GetUserReadorWantBook(string Email, ReadWantEnum readWant) {

            return (from book in db.Table<UserBook>() where book.Email == Email && book.ReadWant == readWant orderby book.DateTime descending select book.BookName).ToList();
        }
        public List<UserBook> GetAllBookUser(string email) {
            return (from book in db.Table<UserBook>() where book.Email == email orderby book.DateTime descending select book).ToList();
        }
        public List<UserBook> GetBookByEmailAndBookName(string email, string bookname) {
            return (from book in db.Table<UserBook>() where book.Email == email && book.BookName == bookname select book).ToList();
        }
      
        public int DeleteBookName(string email) {
            return db.Table<UserBook>().Delete(x => x.Email == email);
        }
        public void UserInsert(UserBook userBook) {
            db.Insert(userBook);
        }
       
        public void BookUserUpdateReadOrWant(UserBook userBook) {
            db.Table<UserBook>().Delete(x => x.BookName == userBook.BookName && x.Email == userBook.Email);
            UserInsert(userBook);
        }
    }
}
