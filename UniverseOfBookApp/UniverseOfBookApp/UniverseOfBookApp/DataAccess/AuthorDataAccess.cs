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
            db.CreateTable<Author>();
        }
        public List<Author> GetAllBook()
        {
            return (from book in db.Table<Author>() select book).ToList();
        }
        public Author GetAuthor(int Id)
        {
            return db.Table<Author>().FirstOrDefault(i => i.AuthorID == Id);
        }
        public void DeleteAllAuthor()
        {
            db.DeleteAll<Author>();
        }
        public void DeleteAuthor(int Id)
        {
            db.Delete<Author>(Id);
        }
        public void AuthorInsert(Author author)
        {
            db.Insert(author);
        }
        public void AuthorUpdate(Author author)
        {
            db.Update(author);
        }

        
    }
}
