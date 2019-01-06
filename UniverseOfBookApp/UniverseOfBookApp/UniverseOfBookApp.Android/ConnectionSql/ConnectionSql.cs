using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using UniverseOfBookApp.DependencyConnection;

using SQLite;
using UniverseOfBookApp.Droid.ConnectionSql;

[assembly: Xamarin.Forms.Dependency(typeof(ConnectionSql))]
namespace UniverseOfBookApp.Droid.ConnectionSql
{
    public class ConnectionSql : SqlConnection
    {
        public SQLiteConnection GetConnection()

        {
            string dbname = "UniverseOfBookApp.db3";    
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(document, dbname);
            var db = new SQLiteConnection(path);
            return db;

        }
    }
}