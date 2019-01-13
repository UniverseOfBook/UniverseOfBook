﻿using SQLite;
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
        public UserBook GetBook(string bookname)
        {
            return db.Table<UserBook>().FirstOrDefault(i => i.BookName == bookname);
        }
        public int GetUserReadorWantCountBook(string Email,ReadWant readWant)
        {
            List<UserBook> userBooks = (from book in db.Table<UserBook>() where book.Email == Email && book.ReadWant == readWant select book).ToList();
            return userBooks.Count;
        }
        public List<String> GetUserReadorWantBook(string Email, ReadWant readWant)
        {

            return (from book in db.Table<UserBook>() where book.Email == Email && book.ReadWant == readWant orderby book.dateTime descending select book.BookName).ToList();
        }

        public UserBook GetBookUser(string Email)
        {
            return db.Table<UserBook>().FirstOrDefault(i => i.Email == Email);
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
