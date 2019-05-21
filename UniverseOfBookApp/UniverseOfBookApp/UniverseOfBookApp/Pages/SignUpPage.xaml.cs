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
    public partial class SignUpPage : ContentPage {
        public UserDataAccess UserDataAccess;
        public User user;

        public SignUpPage() {
            InitializeComponent();
        }

        private async void Submit_Clicked(object sender, EventArgs e) {
            //We create new user here 
            if (Password.Text == PasswordAgain.Text && Email.Text != null && Name.Text != null) {
                UserDataAccess = new UserDataAccess();

                user = new User {
                    Email = Email.Text,
                    Password = Password.Text,
                    UserName = Name.Text,
                    UserType = UserAdmin.User
                };

                int number = UserDataAccess.AddUser(user);
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