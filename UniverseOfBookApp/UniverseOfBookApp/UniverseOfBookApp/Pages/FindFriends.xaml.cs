﻿using System;
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
    public partial class FindFriends : ContentPage {
        public UserFriendDataAccess userFriendDataAccess = new UserFriendDataAccess();
        public UserDataAccess userDataAccess = new UserDataAccess();
        public User user;
        public UserFriends userFriends;
        public FindFriends() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            List<User> users = userDataAccess.GetAllUsers().ToList();
            listView.BindingContext = users;
        }

        private void Follow_Clicked(object sender, EventArgs e) {

            user = (User)listView.SelectedItem;
            userFriends = userFriendDataAccess.getUser(App.UserEmail, user.Email);
            if(userFriends != null) {
                DisplayAlert("Warning", "You already follow this user", "Cancel");
            }
            else {
                UserFriends userFriends1 = new UserFriends();
                userFriends1.UserEmail = App.UserEmail;
                userFriends1.FriendEmail = user.Email;

                userFriendDataAccess.Insert(userFriends1);
                DisplayAlert("Warning", "Now your are following "+user.Name, "Cancel");
            }

        }
    }
}