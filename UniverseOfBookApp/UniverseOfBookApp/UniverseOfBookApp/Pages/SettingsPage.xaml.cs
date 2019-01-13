using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
       
        MediaFile file;

        public SettingsPage() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;
        }

        private void SignOutButtonClicked(object sender, EventArgs e) {
            App.UserEmail = "";
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private async void UploadPhotoClicked(object sender, EventArgs e) {
            await CrossMedia.Current.Initialize();
            try {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
                    return;
                profilePhoto.Source = ImageSource.FromStream(() => {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
                await StoreImages(file.GetStream());
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }

            await StoreImages(file.GetStream());
        }

        public async Task<string> StoreImages(Stream imageStream) {

            DataAccess.UserDataAccess userDataAccess = new DataAccess.UserDataAccess();
            Model.UserClass user = userDataAccess.GetUserByEmail(App.UserEmail);

            var stroageImage = await new FirebaseStorage("universeofbook-60c2f.appspot.com")
                .Child("UsersPhoto")
                .Child(user.Email)
                .PutAsync(imageStream);
            string imgurl = stroageImage;
            return imgurl;
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            UserClass userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            userClass.Name = NameUser.Text;
            userClass.phonenumber =Int32.Parse(PhoneNumber.Text);
          
            if(UserPhotoSource != null)
            {
                profilePhoto.Source = UserPhotoSource.Text;
             userClass.UserPhoto = (profilePhoto.Source).ToString();
            }
            userDataAccess.UserUpdate(userClass);

        }

        private void MaleButton_Clicked(object sender, EventArgs e)
        {
            UserClass userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            userClass.Gender = Gender.Male;
            userDataAccess.UserUpdate(userClass);
            MaleButton.TextColor =Color.FromHex("#c62828");
        }

        private void FemaleButton_Clicked(object sender, EventArgs e)
        {
            UserClass userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            userClass.Gender = Gender.Male;
            userDataAccess.UserUpdate(userClass);
            FemaleButton.TextColor= Color.FromHex("#c62828");
        }
    }
}