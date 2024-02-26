using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using SQLite;
using Microsoft.Maui.Controls;

namespace Login_Android
{
    public partial class ForgotPassword : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        public ForgotPassword()
        {
            InitializeComponent();

            // Initialize SQLite connection
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserData.db3");
            _connection = new SQLiteAsyncConnection(dbPath);

            // Create UserDataTable if it doesn't exist
            _connection.CreateTableAsync<UserData>().Wait();
        }

        public async void SendPasswordReset1(object sender, EventArgs e)
        {
            string senderEmail = "andrewhilton2006@gmail.com";
            string senderPassword = "ectz lkkh veiu kkoa";
            string recipientEmail = ResetPasswordEmailEntry.Text;

            if (string.IsNullOrEmpty(recipientEmail))
            {
                await DisplayAlert("Error", "Please enter your email", "OK");
                return;
            }

            // Retrieve user data from the database
            UserData userData = await _connection.Table<UserData>().FirstOrDefaultAsync(u => u.UserEmail == recipientEmail);

            if (userData == null)
            {
                await DisplayAlert("Error", "No user found with this email", "OK");
                return;
            }
            string thierpassword = userData.Password;

            MailMessage mail = new MailMessage(senderEmail, recipientEmail);
            DisplayAlert("OK", $"{senderEmail}+ {senderPassword}", "OK");
            mail.Subject = "Your password";
            mail.Body = thierpassword;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; // Use 587 for Gmail
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);

            await DisplayAlert("All Good", "Your password was sent to your email", "OK");

            ResetPasswordEmailEntry.Text = null;

            await Navigation.PushAsync(new MainPage());


            //Implement this in the system for muai email
            if (Email.Default.IsComposeSupported)
            {

                string subject = "Hello friends!";
                string body = "It was great to see you last weekend.";
                string[] recipients = new[] { "john@contoso.com", "jane@contoso.com" };

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(recipients)
                };

                await Email.Default.ComposeAsync(message);
            }
        }
    }
}