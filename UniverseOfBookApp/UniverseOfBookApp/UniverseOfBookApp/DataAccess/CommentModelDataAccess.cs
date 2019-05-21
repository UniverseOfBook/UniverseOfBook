using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace UniverseOfBookApp.DataAccess {
  public  class CommentModelDataAccess {
        static SQLiteConnection db;

        public CommentModelDataAccess() {
            db = DependencyService.Get<ISqlConnection>().GetConnection();
            db.CreateTable<CommentModel>();
        }
           public List<String> getCommentOfBook(string bookname) {
            return (from comment in db.Table<CommentModel>() where comment.bookname == bookname orderby comment.commentOfBook select comment.commentOfBook).ToList();
        } 
    }
}
