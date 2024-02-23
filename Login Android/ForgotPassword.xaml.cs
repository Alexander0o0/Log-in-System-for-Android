using System.Net;
using System.Net.Mail;

namespace Login_Android;

public partial class ForgotPassword : ContentPage
{
	public ForgotPassword()
	{
		InitializeComponent();
	}

	public async void SendPasswordReset(object sender, EventArgs e)
	{
        UserData userData = new UserData();

        string UsersPassword = userData.Password;

        string senderEmail = "ak05259065@priestley.ac.uk";
		string senderPassword = "x";

		string recipientEmail = ResetPasswordEmailEntry.Text;

		MailMessage mail = new MailMessage(senderEmail, recipientEmail);

		mail.Subject = "Your password";
		mail.Body = UsersPassword;

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
        smtpClient.Port = 587;
        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        smtpClient.EnableSsl = true;
        smtpClient.Send(mail);

        DisplayAlert("All Good", "Your password was sent to your email", "OK");

		ResetPasswordEmailEntry.Text = null;

        await Navigation.PushAsync(new MainPage());
    }
}