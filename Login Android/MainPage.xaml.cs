using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using SQLite;


namespace Login_Android
{
    public partial class MainPage : ContentPage
    {
        string? username = null;
        string? password = null;

        private SQLiteAsyncConnection _connection;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            // Initialize SQLite connection
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserData.db3");
            _connection = new SQLiteAsyncConnection(dbPath);

            // Create UserDataTable if it doesn't exist
            _connection.CreateTableAsync<UserData>().Wait();
        }

        private async void LogInFunction(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            var userData = await _connection.Table<UserData>().FirstOrDefaultAsync();

            if (username == userData.Username && password == userData.Password)
            {
                Navigation.PushAsync(new Home());
            }
            else
            {
                // Deny access
                DisplayAlert("Error", "Invalid username or password", "OK");
            }


        }
        private void SignUpFunction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }
    }
}
            