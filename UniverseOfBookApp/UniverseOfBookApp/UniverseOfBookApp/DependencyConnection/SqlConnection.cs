using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniverseOfBookApp.DependencyConnection
{
   public interface SqlConnection
    {
        SQLiteConnection GetConnection();
    }
}
