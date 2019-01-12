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
    public class BookDataAccess
    {
        static SQLiteConnection db;
        public const string DBname = "UniverseOfBookApp.db3";

        public BookDataAccess()
        {
            db = DependencyService.Get<SqlConnection>().GetConnection();
            db.CreateTable<BookClass>();
        }
        public List<BookClass> GetAllBook()
        {
            return (from book in db.Table<BookClass>() select book).ToList();
        }
        public BookClass GetBook(int Id)
        {
            return db.Table<BookClass>().FirstOrDefault(i => i.BookID == Id);
        }
        public List<BookClass> GetAllBookByCategory(CategoryEnum category) {
            return (from book in db.Table<BookClass>() where book.Category == category select book).ToList();
        }
        public int DeleteBookName(String Bookname)
        {
            return db.Table<BookClass>().Delete(x => x.BookName == Bookname);
        }
        public void DeleteAllBook()
        {
            db.DeleteAll<BookClass>();
        }
        public void DeleteBook(int Id)
        {
            db.Delete<BookClass>(Id);
        }
        public int BookInsert(BookClass book)
        {
          return  db.Insert(book);
        }
        public void BookUpdate(BookClass book)
        {
            db.Update(book);
        }

    }
}
