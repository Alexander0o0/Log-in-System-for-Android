using Microsoft.Maui.Controls;
using System;
using System.IO;
using SQLite;

namespace Login_Android
{
    public partial class SignUp : ContentPage
    {
        SQLiteAsyncConnection _connection;

        public SignUp()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            // Initialize SQLite connection
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserData.db3");
            _connection = new SQLiteAsyncConnection(dbPath);

            // Create UserDataTable if it doesn't exist
            _connection.CreateTableAsync<UserData>().Wait();
        }

        private async void SaveUserDataFunction(object sender, EventArgs e)
        {
            // Create or update user data
            var userData = new UserData
            {
                FirstName = FirstNameEntry.Text,
                SecondName = SecondNameEntry.Text,
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };

            // Insert or replace user data
            await _connection.InsertOrReplaceAsync(userData);

            // Optionally, display a confirmation message
            await DisplayAlert("Success", "User data saved successfully", "OK");
        }
    }

    // Model class for user data
    public class UserData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
