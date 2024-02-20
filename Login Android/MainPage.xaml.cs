using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;


namespace Login_Android
{
    public partial class MainPage : ContentPage
    {
        string? username = null;
        string? password = null;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        private void LogInFunction(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "Admin" && password == "1234")
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
            