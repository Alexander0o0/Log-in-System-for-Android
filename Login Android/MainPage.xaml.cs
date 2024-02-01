using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace Login_Android
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LogInFunction(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;

            if (username == "user")
            {
                db_class.();
            }
        }
        
        private void SignUpFunction(object sender, EventArgs e)
        {

        }
    }

}
