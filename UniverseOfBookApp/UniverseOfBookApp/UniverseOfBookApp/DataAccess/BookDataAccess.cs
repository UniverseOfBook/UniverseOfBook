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
            db.CreateTable<Book>();
        }
        public List<Book> GetAllBook()
        {
            return (from book in db.Table<Book>() select book).ToList();
        }
        public Book GetBook(int Id)
        {
            return db.Table<Book>().FirstOrDefault(i => i.BookID == Id);
        }
        public void DeleteAllBook()
        {
            db.DeleteAll<Book>();
        }
        public void DeleteBook(int Id)
        {
            db.Delete<Book>(Id);
        }
        public void BookInsert(Book book)
        {
            db.Insert(book);
        }
        public void BookUpdate(Book book)
        {
            db.Update(book);
        }

    }
}
