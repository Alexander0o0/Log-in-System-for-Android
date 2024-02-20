using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;

namespace Login_Android
{
    public partial class SignUp : ContentPage
    {
        List<UserData> userList = new List<UserData>(); // List to store user data

        public SignUp()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            // Load previously saved user data
            LoadUserData();
        }

        private void SaveUserDataFunction(object sender, EventArgs e)
        {
            // Create a new UserData object and populate it with the entered data
            UserData newUser = new UserData
            {
                FirstName = FirstNameEntry.Text,
                SecondName = SecondNameEntry.Text,
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };

            // Add the new user data to the list
            userList.Add(newUser);

            // Save the updated list of user data
            SaveUserData();

            // Optionally, display a confirmation message
            DisplayAlert("Success", "User data saved successfully", "OK");
        }

        private void LoadUserData()
        {
            // Retrieve the list of user data from Preferences
            string serializedData = Preferences.Get("UserList", "");

            // Deserialize the data back into a list of UserData objects
            if (!string.IsNullOrEmpty(serializedData))
            {
                userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserData>>(serializedData);
            }
        }

        private void SaveUserData()
        {
            // Serialize the list of user data and save it to Preferences
            string serializedData = Newtonsoft.Json.JsonConvert.SerializeObject(userList);
            Preferences.Set("UserList", serializedData);
        }
    }

    // Model class for user data
    public class UserData
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}