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

            UserClass userClass = userDataAccess.GetUserByEmail(App.UserEmail);

            if ((userClass.UserPhoto != (null))) {
                if (userClass.UserPhoto.Replace("File: ", "") != "" || userClass.UserPhoto.Replace("Uri: ", "") != "") {
                    if (userClass.UserPhoto.StartsWith("File"))
                        profilePhoto.Source = userClass.UserPhoto.Replace("File: ", "");
                    else
                        profilePhoto.Source = userClass.UserPhoto.Replace("Uri: ", "");
                }
            }

            if (userClass.Gender == Gender.Male) {
                MaleButton.TextColor = Color.FromHex("#c62828");
                MaleButton.FontAttributes = FontAttributes.Bold;
            }
            else {
                FemaleButton.TextColor = Color.FromHex("#c62828");
                FemaleButton.FontAttributes = FontAttributes.Bold;
            }
            if ((userClass.UserPhoto != (null))) {
                if (userClass.UserPhoto.StartsWith("File"))
                    UserPhotoSource.Text = userClass.UserPhoto.Replace("File: ", "");
                else
                    UserPhotoSource.Text = userClass.UserPhoto.Replace("Uri: ", "");
            }

            PhoneNumber.Text = userClass.Phonenumber;
            NameUser.Text = userClass.Name;
            userNameLabel.Text = userClass.UserName;
            emailLabel.Text = userClass.Email;
        }

        private void SignOutButtonClicked(object sender, EventArgs e) {
            App.UserEmail = "";
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            UserClass userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            userClass.Name = NameUser.Text;
            userClass.Phonenumber = PhoneNumber.Text;
          
            if(UserPhotoSource.Text != "")
            {
             profilePhoto.Source = UserPhotoSource.Text;
             userClass.UserPhoto = (profilePhoto.Source).ToString();
            }
            userDataAccess.UserUpdate(userClass);

        }

        private void MaleButton_Clicked(object sender, EventArgs e)
        {
            UserClass userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            if (userClass.Gender == Gender.Male)
                return;
            userClass.Gender = Gender.Male;
            userDataAccess.UserUpdate(userClass);
            MaleButton.TextColor =Color.FromHex("#c62828");
            MaleButton.FontAttributes = FontAttributes.Bold;

            FemaleButton.TextColor = Color.FromHex("#6d6d6d");
            FemaleButton.FontAttributes = FontAttributes.None;
        }

        private void FemaleButton_Clicked(object sender, EventArgs e)
        {
            UserClass userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            if (userClass.Gender == Gender.Female)
                return;
            userClass.Gender = Gender.Female;
            userDataAccess.UserUpdate(userClass);
            FemaleButton.TextColor= Color.FromHex("#c62828");
            FemaleButton.FontAttributes = FontAttributes.Bold;

            MaleButton.TextColor = Color.FromHex("#6d6d6d");
            MaleButton.FontAttributes = FontAttributes.None;
        }
    }
}