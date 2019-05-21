﻿using System;
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
using Java.Nio.FileNio;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(ConnectionSql))]
namespace UniverseOfBookApp.Droid.ConnectionSql {
    public class ConnectionSql : ISqlConnection {
        public SQLiteConnection GetConnection() {
            string dbname = "UniverseOfBookAppDatabase.db3";
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(document, dbname);

            if (!File.Exists(path))
                File.Create(path);

            var db = new SQLiteConnection(path);
            return db;
        }
    }
}