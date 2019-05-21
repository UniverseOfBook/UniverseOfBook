using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage {
        public UserDataAccess UserDataAccess;
        public UserClass user;

        public SignUp() {
            InitializeComponent();
        }

        private async void Submit_Clicked(object sender, EventArgs e) {
            //We create new user here 
            if (Password.Text == PasswordAgain.Text && Email.Text != null && Name.Text != null) {
                user = new UserClass();
                UserDataAccess = new UserDataAccess();

                user.Email = Email.Text;
                user.Password = Password.Text;
                user.UserName = Name.Text;
                user.Useradmin = UserAdmin.User;
                
                int number = UserDataAccess.UserInsert(user);
                if (number > 0) {
                    await DisplayAlert("Sign Up", "Thanks for joining us " + Name.Text, "OK");
                    await Navigation.PopAsync();
                }
                else {
                    await DisplayAlert("Sign Up", "Didn't add  " + Name.Text, "OK");
                }
            }
        }

        private async void BackButtonClicked(object sender, EventArgs e) {
            await Navigation.PopAsync();
        }
    }
}