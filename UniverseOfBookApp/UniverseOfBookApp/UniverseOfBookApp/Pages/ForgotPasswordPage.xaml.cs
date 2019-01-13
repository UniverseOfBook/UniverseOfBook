using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage {
        public ForgotPasswordPage() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
        }

        private async void BackButtonClicked(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }

        private async void SubmitButtonClicked(object sender, EventArgs e) {

            UserDataAccess userDataAccess = new UserDataAccess();
            UserClass userClass = userDataAccess.GetUserByEmail(emailEntry.Text);

            if (userClass == null) {
                await DisplayAlert("No user", "There is no user in that email, please check your email", "OK");
                return;
            }

            string mailSender = "kitapevreni26@gmail.com";
            string password = "Xamarinkitap26";
            string toMail = userClass.Email;
            string subject = "Forgotten Password";
            string body = "Your password is " + userClass.Password;

            try {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("smtp.gmail.com", 587);
                mail.From = new MailAddress(mailSender);
                mail.To.Add(toMail);
                mail.Subject = subject;
                mail.Body = body;
                smtpServer.Credentials = new NetworkCredential(mailSender, password);
                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = true;
                smtpServer.Send(mail);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            await Navigation.PushAsync(new LoginPage());
        }
    }
}