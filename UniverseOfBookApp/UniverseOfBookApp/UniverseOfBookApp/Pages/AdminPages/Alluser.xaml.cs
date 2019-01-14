using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages.AdminPages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Alluser : ContentPage {
        public UserDataAccess userDataAccess = new UserDataAccess();
        public UserClass user;

        public Alluser() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            List<UserClass> users = new List<UserClass>();
            users = userDataAccess.GetAllUsers().ToList();
            listView.BindingContext = users;
        }

        private async void DeleteUser_Clicked(object sender, EventArgs e) {

            var answer = await DisplayAlert("Question?", "Would you like to delete?", "Yes", "No");
            if (answer) {
                UserClass user = new UserClass();
                user = (UserClass)listView.SelectedItem;
                userDataAccess.DeleteUserName(user.UserName);
                UserBookDataAccess userBookDataAccess = new UserBookDataAccess();
                userBookDataAccess.DeleteBookName(user.Email);
                App.UserEmail = "";
            }
            Navigation.InsertPageBefore(new Alluser(), this);
            await Navigation.PopAsync();
           
        }

        private async void AllUserDelete_Clicked(object sender, EventArgs e) {
            var answer = await DisplayAlert("Question?", "Would you like to delete all users ?", "Yes", "No");
            if (answer) {
                userDataAccess.DeleteAllUser();
                App.UserEmail = "";
            }
            Navigation.InsertPageBefore(new Alluser(), this);
            await Navigation.PopAsync();
        }

        //public void Click()
        // {

        //     user = new User();
        // user.Name  = userDataAccess.GetUser(2).Name;
        //     Debug.WriteLine(user.Name);
        // }
    }
}