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
            string enteredUsername = UsernameEntry.Text;
            string enteredPassword = PasswordEntry.Text;

            // Retrieve all users from the database
            var allUsers = await _connection.Table<UserData>().ToListAsync();

            // Check if any user's username and password match the entered credentials
            bool isLoggedIn = false;
            foreach (var user in allUsers)
            {
                if (enteredUsername == user.Username && enteredPassword == user.Password)
                {
                    isLoggedIn = true;
                    break;
                }
            }

            if (isLoggedIn)
            {
                // If credentials match, navigate to Home page
                await Navigation.PushAsync(new Home());

                UsernameEntry.Text = null;
                PasswordEntry.Text = null;
            }
            else
            {
                // If credentials don't match, display an error message
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private void SignUpFunction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }
        private async void ForgotPasswordFunction(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }
    }
}
            