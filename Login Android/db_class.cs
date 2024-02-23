using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Login_Android
{
    public class UserData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Define the GetAllUserData method to retrieve all user data from the database
        public static async Task<List<UserData>> GetAllUserData(SQLiteAsyncConnection connection)
        {
            return await connection.Table<UserData>().ToListAsync();
        }
    }
}
