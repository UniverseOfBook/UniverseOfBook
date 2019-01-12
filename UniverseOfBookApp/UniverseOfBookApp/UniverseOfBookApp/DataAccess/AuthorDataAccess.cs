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
   public class AuthorDataAccess
    {
        static SQLiteConnection db;
        public const string DBname = "UniverseOfBookApp.db3";

        public AuthorDataAccess()
        {
            db = DependencyService.Get<SqlConnection>().GetConnection();
            db.CreateTable<AuthorClass>();
        }

        public List<BookClass> GetBooks(string name)
        {
            return (from book in db.Table<BookClass>() where book.AuthorName == name select book).ToList();
        }
        public List<AuthorClass> GetAllAuthor()
        {
            return (from author in db.Table<AuthorClass>() select author).ToList();
        }
        public List<String> Authors()
        {
            return (from author in db.Table<AuthorClass>() select author.AuthorName).ToList();
        }
        public int DeleteAuthorName(String AuthorName)
        {
            return db.Table<AuthorClass>().Delete(x => x.AuthorName == AuthorName);
        }
        public AuthorClass GetAuthor(int Id)
        {
            return db.Table<AuthorClass>().FirstOrDefault(i => i.AuthorID == Id);
        }
        public AuthorClass GetAuthorbyName(String name)
        {
            return db.Table<AuthorClass>().FirstOrDefault(i => i.AuthorName ==name);
        }
        public void DeleteAllAuthor()
        {
            db.DeleteAll<AuthorClass>();
        }
        public void DeleteAuthor(int Id)
        {
            db.Delete<AuthorClass>(Id);
        }
        public int AuthorInsert(AuthorClass author)
        {
          return  db.Insert(author);
        }
        public void AuthorUpdate(AuthorClass author)
        {
            db.Update(author);
        }

        
    }
}
