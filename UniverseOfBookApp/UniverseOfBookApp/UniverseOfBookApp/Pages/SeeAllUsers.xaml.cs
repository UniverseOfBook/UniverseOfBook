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
            SeeAllFriends();
        }

        public void SeeAllFriends() {
            List<UserFriends> userFriends = userFriendDataAccess.GetAllFriends(App.UserEmail).ToList();
            if(userFriends.Count == 0) {
                Label label = new Label() {
                    Text = "You don't have any friends yet",
                    FontSize = 22,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0,0,0,200)
                };
                MyStackLayout.Children.Add(label);
                return;
            }
            foreach (UserFriends userFriend in userFriends) {
                user = userDataAccess.GetUserByEmail(userFriend.FriendEmail);
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