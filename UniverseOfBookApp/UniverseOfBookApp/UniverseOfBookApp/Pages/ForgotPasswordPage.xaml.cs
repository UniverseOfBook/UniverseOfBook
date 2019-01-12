using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage {
        public ForgotPasswordPage() {
            InitializeComponent();
        }

        private async void BackButtonClicked(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }

        private async void SubmitButtonClicked(object sender, EventArgs e) {

            string mailSender = "kitapevreni26@gmail.com";
            string password = "";
            string toMail = "";
            string subject = "Forgotten Password";
            string body = "password";
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