using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage {
        DataAccess.UserDataAccess userDataAccess = new DataAccess.UserDataAccess();

        public SettingsPage() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;

            User user = userDataAccess.GetUserByEmail(App.UserEmail);

            if ((user.UserPhoto != (null))) {
                if (user.UserPhoto.Replace("File: ", "") != "" || user.UserPhoto.Replace("Uri: ", "") != "") {
                    if (user.UserPhoto.StartsWith("File"))
                        profilePhoto.Source = user.UserPhoto.Replace("File: ", "");
                    else
                        profilePhoto.Source = user.UserPhoto.Replace("Uri: ", "");
                }
            }

            if (user.Gender == GenderEnum.Male) {
                MaleButton.TextColor = Color.FromHex("#c62828");
                MaleButton.FontAttributes = FontAttributes.Bold;
            }
            else {
                FemaleButton.TextColor = Color.FromHex("#c62828");
                FemaleButton.FontAttributes = FontAttributes.Bold;
            }
            if ((user.UserPhoto != (null))) {
                if (user.UserPhoto.StartsWith("File"))
                    UserPhotoSource.Text = user.UserPhoto.Replace("File: ", "");
                else
                    UserPhotoSource.Text = user.UserPhoto.Replace("Uri: ", "");
            }

            PhoneNumber.Text = user.PhoneNumber;
            NameUser.Text = user.Name;
            userNameLabel.Text = user.UserName;
            emailLabel.Text = user.Email;
        }

        private void SignOutButtonClicked(object sender, EventArgs e) {
            App.UserEmail = "";
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void SubmitButton_Clicked(object sender, EventArgs e) {
            User user = userDataAccess.GetUserByEmail(App.UserEmail);
            user.Name = NameUser.Text;
            user.PhoneNumber = PhoneNumber.Text;

            if (UserPhotoSource.Text != "") {
                profilePhoto.Source = UserPhotoSource.Text;
                user.UserPhoto = (profilePhoto.Source).ToString();
            }
            userDataAccess.UpdateUser(user);

        }

        private void MaleButton_Clicked(object sender, EventArgs e) {
            User userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            if (userClass.Gender == GenderEnum.Male)
                return;
            userClass.Gender = GenderEnum.Male;
            userDataAccess.UpdateUser(userClass);
            MaleButton.TextColor = Color.FromHex("#c62828");
            MaleButton.FontAttributes = FontAttributes.Bold;

            FemaleButton.TextColor = Color.FromHex("#6d6d6d");
            FemaleButton.FontAttributes = FontAttributes.None;
        }

        private void FemaleButton_Clicked(object sender, EventArgs e) {
            User userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            if (userClass.Gender == GenderEnum.Female)
                return;
            userClass.Gender = GenderEnum.Female;
            userDataAccess.UpdateUser(userClass);
            FemaleButton.TextColor = Color.FromHex("#c62828");
            FemaleButton.FontAttributes = FontAttributes.Bold;

            MaleButton.TextColor = Color.FromHex("#6d6d6d");
            MaleButton.FontAttributes = FontAttributes.None;
        }
    }
}