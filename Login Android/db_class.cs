using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace Login_Android
{
    internal class db_class
    {
        public static string _dbPath = string.Empty;

        public static void create_db()
        {
            var databaseName = "Users.db";
            _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), databaseName);

            using (SQLiteConnection db = new SQLiteConnection($"Data Source={_dbPath};Version=3;"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS UserData (uid INTEGER PRIMARY KEY, " +
                    "Username VARCHAR(2048) NULL, " +
                    "Password VARCHAR(2048) NULL)";

                using (SQLiteCommand createTable = new SQLiteCommand(tableCommand, db))
                {
                    createTable.ExecuteNonQuery();
                }
            }
        }
    }
}
/*
public static void add_data()
{
    using (SqliteConnection db = new SqliteConnection($"Filename={_dbPath}"))
    {
        db.Open();

        SqliteCommand insertCommand = new SqliteCommand();
        insertCommand.Connection = db;

        // Use parameterized query to prevent SQL injection attacks
        insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
        insertCommand.Parameters.AddWithValue("@Entry", "Original data .. ");

        insertCommand.ExecuteReader();

        db.Close();
    }
}

public static List<String> get_data()
{
    List<String> entries = new List<string>();

    using (SqliteConnection db = new SqliteConnection($"Filename={_dbPath}"))
    {
        db.Open();

        SqliteCommand selectCommand = new SqliteCommand
            ("SELECT Text_Entry from MyTable", db);

        SqliteDataReader query = selectCommand.ExecuteReader();

        while (query.Read())
        {
            entries.Add(query.GetString(0));
        }

        db.Close();
    }

    return entries;
}

public static void delete_data(string var_item)
{
    using (SqliteConnection db = new SqliteConnection($"Filename={_dbPath}"))
    {
        db.Open();

        SqliteCommand deleteCommand = new SqliteCommand();
        deleteCommand.Connection = db;

        Console.WriteLine("Abount to delete data " + var_item);

        // Use parameterized query to prevent SQL injection attacks
        deleteCommand.CommandText = "DELETE FROM MyTable WHERE Text_Entry = @Entry;";
        deleteCommand.Parameters.AddWithValue("@Entry", var_item);

        deleteCommand.ExecuteReader();

        db.Close();
    }
}
}
}

*/