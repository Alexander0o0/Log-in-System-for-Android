using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Login_Android
{
    internal class db_class
    {
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
        }
    }
}
