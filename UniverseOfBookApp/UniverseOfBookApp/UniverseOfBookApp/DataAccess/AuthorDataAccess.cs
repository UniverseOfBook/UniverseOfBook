using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;

namespace UniverseOfBookApp.DataAccess {
    public class AuthorDataAccess {
        static SQLiteConnection db;

        public AuthorDataAccess() {
            db = DependencyService.Get<SqlConnection>().GetConnection();
            db.CreateTable<Author>();
        }
        public List<Book> GetBooks(string name) {
            return (from book in db.Table<Book>() where book.AuthorName == name select book).ToList();
        }
        public List<Author> GetAllAuthor() {
            return (from author in db.Table<Author>() select author).ToList();
        }
        public List<String> Authors() {
            return (from author in db.Table<Author>() select author.AuthorName).ToList();
        }
        public int DeleteAuthorName(String AuthorName) {
            return db.Table<Author>().Delete(x => x.AuthorName == AuthorName);
        }
        public Author GetAuthorbyName(String name) {
            return db.Table<Author>().FirstOrDefault(i => i.AuthorName == name);
        }
        public void DeleteAllAuthor() {
            db.DeleteAll<Author>();
        }
        public int AuthorInsert(Author author) {
            return db.Insert(author);
        }
    }
}
