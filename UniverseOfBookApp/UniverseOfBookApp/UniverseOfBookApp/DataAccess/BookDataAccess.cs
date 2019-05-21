using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;

namespace UniverseOfBookApp.DataAccess {
    public class BookDataAccess {
        static SQLiteConnection db;

        public BookDataAccess() {
            db = DependencyService.Get<ISqlConnection>().GetConnection();
            db.CreateTable<Book>();
        }
        public List<Book> GetAllBook() {
            return (from book in db.Table<Book>() select book).ToList();
        }
        public List<string> GetAllBooksName() {
            return (from book in db.Table<Book>() select book.BookName).ToList();
        }
        public Book GetBookByName(string BookName) {
            return db.Table<Book>().FirstOrDefault(i => i.BookName == BookName);
        }
        public List<String> GetBookByAuthor(string AuthorName) {
            return (from book in db.Table<Book>() where book.AuthorName == AuthorName select book.BookName).ToList();
        }
        public Book GetBookBySource(string bookPhoto) {
            return db.Table<Book>().FirstOrDefault(i => i.Bookphoto == bookPhoto);
        }
        public List<Book> GetAllBookByCategory(CategoryEnum category) {
            return (from book in db.Table<Book>() where book.Category == category select book).ToList();
        }
        public int DeleteBookName(String Bookname) {
            return db.Table<Book>().Delete(x => x.BookName == Bookname);
        }
        public void DeleteAllBook() {
            db.DeleteAll<Book>();
        }
        public int BookInsert(Book book) {
            return db.Insert(book);
        }
    }
}
