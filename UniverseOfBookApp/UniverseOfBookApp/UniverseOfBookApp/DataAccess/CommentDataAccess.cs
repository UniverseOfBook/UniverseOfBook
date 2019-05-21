using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace UniverseOfBookApp.DataAccess {
    public class CommentDataAccess {
        static SQLiteConnection db;

        public CommentDataAccess() {
            db = DependencyService.Get<ISqlConnection>().GetConnection();
            db.CreateTable<Comment>();
        }
        public List<Comment> GetCommentOfBook(string bookname) {
            return (from comment in db.Table<Comment>() where comment.Bookname == bookname orderby comment.Date select comment).ToList();
        }
        public int AddComment(Comment comment) {
            return db.Insert(comment);
        }
        public void DeleteAllComment() {
            db.DeleteAll<Comment>();
        }

    }
}
