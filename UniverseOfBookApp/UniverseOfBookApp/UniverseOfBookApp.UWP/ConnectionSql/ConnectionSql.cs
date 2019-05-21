using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UniverseOfBookApp.DependencyConnection;

using SQLite;
using UniverseOfBookApp.Droid.ConnectionSql;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(ConnectionSql))]
namespace UniverseOfBookApp.Droid.ConnectionSql {
    public class ConnectionSql : ISqlConnection {
        public SQLiteConnection GetConnection() {
            string dbname = "UniverseOfBookApp.db3";

            var document = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(document, dbname);
            if (!File.Exists(path)) File.Create(path);
            var db = new SQLiteConnection(path);

            return db;
        }
    }
}