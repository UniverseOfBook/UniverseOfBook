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

        public SeeAllUsers() {
            InitializeComponent();
            SeeAllFriends();
        }

        public void SeeAllFriends() {
            List<UserFriends> userFriendsList = userFriendDataAccess.GetAllFriends(App.UserEmail).ToList();
            if (userFriendsList.Count == 0) {
                Label label = new Label() {
                    Text = "You don't have any friends yet",
                    FontSize = 22,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Margin = new Thickness(0, 0, 0, 200)
                };
                MyStackLayout.Children.Add(label);
                return;
            }
            foreach (UserFriends userFriend in userFriendsList) {
                user = userDataAccess.GetUserByEmail(userFriend.FriendEmail);
                Frame frame = new Frame() { CornerRadius = 10 };
                StackLayout stackLayout = new StackLayout() {
                    Orientation = StackOrientation.Horizontal
                };

                Image userPhoto = new Image {
                    Source = user.UserPhoto,
                    HeightRequest = 50
                };
                stackLayout.Children.Add(userPhoto);

                Label label1 = new Label() {
                    FontSize = 23,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                label1.Text = user.UserName;
                stackLayout.Children.Add(label1);

                Button button = new Button() {
                    CornerRadius = 15,
                    BackgroundColor = Color.FromHex("#c62828"),
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };
                button.Text = "Unfollow";
                button.Clicked += UnfollowButtonClicked;
                stackLayout.Children.Add(button);
                frame.Content = stackLayout;
                MyStackLayout.Children.Add(frame);
            }
        }
        private async void UnfollowButtonClicked(object sender, EventArgs e) {
            userFriendDataAccess.DeleteUserFriends(user.Email);

            DisplayAlert("Warning", "You unfollowed now", "OK");

            await Navigation.PushAsync(new ProfilePage());
        }
    }
}