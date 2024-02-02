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
        string username = "";
        string password = "";
        public MainPage()
        {
            InitializeComponent();
        }

        private void LogInFunction(object sender, EventArgs e)
        {
            Console.WriteLine("Reached Login function");
            username = UsernameEntry.Text;
            db_class.create_db();

        }
    }
}
        /*
            if (username == "admin")
            {
                db_class.create_db();
                //db_class.add_data();
                List<String> entries = db_class.get_data();
                foreach (var entry in entries)
                {
                    DisplayAlert("Alert", entry, "OK");
                }

                DisplayAlert("Alert", "No more data in table", "OK");

                db_class.delete_data("Original data .. ");
            }
            else
            {
                DisplayAlert("Alert", "You are not admin", "OK");
            }
        }
        
        private void SignUpFunction(object sender, EventArgs e)
        {

        }
    }

}

            */