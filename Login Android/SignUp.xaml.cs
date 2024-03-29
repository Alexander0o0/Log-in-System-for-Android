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

            if (PasswordEntry.Text != ReEnterPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Make sure you enter your password twice", "OK");

                PasswordEntry.Text = null;
                ReEnterPasswordEntry.Text = null;
            }
            else
            {

                // Get all existing usernames from the database
                var existingUsers = await _connection.Table<UserData>().ToListAsync();

                bool usernameExists = false;
                bool emailExists = false;

                // Check if the entered username already exists
                foreach (var user in existingUsers)
                {
                    if (user.UserEmail == EmailEntry.Text)
                    {
                        emailExists = true;
                        break;
                    }
                }

                if (emailExists)
                {
                    // If email already exists, display an error message
                    await DisplayAlert("Error", "Email already exists. Please choose a different one.", "OK");

                    EmailEntry.Text = null;
                }
                else
                {
                    if (usernameExists)
                    {
                        // If username already exists, display an error message
                        await DisplayAlert("Error", "Username already exists. Please choose a different one.", "OK");


                    }
                    else
                    {
                        // Create new user data
                        var newUser = new UserData
                        {
                            FirstName = FirstNameEntry.Text,
                            SecondName = SecondNameEntry.Text,
                            UserEmail = EmailEntry.Text,
                            Username = UsernameEntry.Text,
                            Password = PasswordEntry.Text
                        };

                        // Insert new user
                        await _connection.InsertAsync(newUser);

                        // Optionally, display a confirmation message
                        await DisplayAlert("Success", "User data saved successfully", "OK");

                        FirstNameEntry.Text = null;
                        SecondNameEntry.Text = null;
                        EmailEntry.Text = null;
                        UsernameEntry.Text = null;
                        PasswordEntry.Text = null;
                        ReEnterPasswordEntry = null;

                        Navigation.PushAsync(new MainPage());
                    }
                }
            }
        }
    }
}