using System;
using System.Collections.Generic;
using System.Linq;
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
            await Navigation.PushAsync(new LoginPage());
        }
    }
}