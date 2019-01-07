using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void ForgotPasswordTappedAsync(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPasswordPage());
        }

        private async void SignupTappedAsynch(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUp());
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomePage());
        }
    }
}