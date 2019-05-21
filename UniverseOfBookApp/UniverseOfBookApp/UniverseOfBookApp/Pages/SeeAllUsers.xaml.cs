using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeeAllUsers : ContentPage {
        public UserFriendDataAccess userFriendDataAccess = new UserFriendDataAccess();
        public UserDataAccess userDataAccess = new UserDataAccess();
        public User user;
        public UserFriends userFriends;
        public SeeAllUsers() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            SeeALLFriends();
        }


        public void SeeALLFriends() {
            List<UserFriends> userFriend = userFriendDataAccess.GetAllFriends(App.UserEmail).ToList();
            for (int i = 0; i < userFriend.Count; i++) {
                user = userDataAccess.GetUserByEmail(userFriend[i].FriendEmail);
                Frame frame = new Frame() { CornerRadius = 10 };
                StackLayout stackLayout = new StackLayout();

                Label label1 = new Label() { FontSize = 18, HorizontalOptions = LayoutOptions.Start };
                label1.Text = user.Name;
                stackLayout.Children.Add(label1);

                Image userPhoto = new Image { Source = user.UserPhoto, HorizontalOptions = LayoutOptions.End };
                stackLayout.Children.Add(userPhoto);

                Button button = new Button() { CornerRadius = 20, BackgroundColor = Color.Red };
                button.Text = "Unfollow";
                button.Clicked += UnfollowButtonClicked;
                stackLayout.Children.Add(button);
                frame.Content = stackLayout;
                MyStackLayout.Children.Add(frame);

            }
        }
        private void UnfollowButtonClicked(object sender, EventArgs e) {
            userFriendDataAccess.DeleteUserFriends(user.Email);

        }

        private async void SeeAllUser_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FindFriendsPage());
        }
    }
}