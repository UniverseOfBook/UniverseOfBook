﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using UniverseOfBookApp.Pages.AdminPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {

        public UserDataAccess userDataAccess;
        public UserClass user;

        public LoginPage() {
            InitializeComponent();
        }

        private async void ForgotPasswordTappedAsync(object sender, EventArgs e) {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        private async void SignupTappedAsynch(object sender, EventArgs e) {
            await Navigation.PushAsync(new SignUp());
        }

        private async void LoginButtonClicked(object sender, EventArgs e) {
            userDataAccess = new UserDataAccess();
            user = userDataAccess.Login(Email.Text, Password.Text);

            if (user != null) {
                if (user.useradmin == UserAdmin.Admin) {

                    Navigation.InsertPageBefore(new AdminPage(), this);
                    await Navigation.PopAsync();
                }
                else {
                    App.UserEmail = Email.Text;
                    Navigation.InsertPageBefore(new MainTabbedPage(), this);
                    await Navigation.PopAsync();
                }
            }
            else { await DisplayAlert("Warning", "Please check your Email and Password", "Cancel"); }

            //Navigation.InsertPageBefore(new MainTabbedPage(), this);
            //await Navigation.PopAsync();
        }
    }
}
