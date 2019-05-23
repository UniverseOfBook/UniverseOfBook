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
    public partial class ProfilePage : ContentPage {
        public ProfilePage() {
            InitializeComponent();
            UserDataAccess userDataAccess = new UserDataAccess();
            UserFriendDataAccess userFriendDataAccess = new UserFriendDataAccess();
            UserBookDataAccess userBookDataAccess = new UserBookDataAccess();
            User userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            userName.Text = userClass.UserName;
            int wantBookCount = userBookDataAccess.GetUserReadorWantCountBook(App.UserEmail, ReadWantEnum.Want);
            int readBookCount = userBookDataAccess.GetUserReadorWantCountBook(App.UserEmail, ReadWantEnum.Read);
            int friendsCount = userFriendDataAccess.CountFriends(App.UserEmail);
            wantLabel.Text = wantBookCount.ToString();
            readLabel.Text = readBookCount.ToString();
            FriendsLabel.Text = friendsCount.ToString();

            if (userClass.UserPhoto != "" && userClass.UserPhoto != null) {
                if (userClass.UserPhoto.StartsWith("File"))
                    ProfilePhotoImage.Source = userClass.UserPhoto.Replace("File: ", "");
                else
                    ProfilePhotoImage.Source = userClass.UserPhoto.Replace("Uri: ", "");
            }

            wantGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            wantGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            readGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            readGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            if (wantBookCount == 0 && readBookCount == 0) {
                GridStacklayout.IsVisible = false;
                NoBookStacklayout.IsVisible = true;
            }
            else {
                GridStacklayout.IsVisible = true;
                NoBookStacklayout.IsVisible = false;
                GetAllBooksToProfilePage(wantGrid, ReadWantEnum.Want);
                GetAllBooksToProfilePage(readGrid, ReadWantEnum.Read);
            }
        }

        public void GetAllBooksToProfilePage(Grid grid, ReadWantEnum readWant) {
            //Console.WriteLine("UpdateBook: " + wantGrid.RowDefinitions.Count + " " + readGrid.RowDefinitions.Count);
            UserBookDataAccess userBookDataAccess = new UserBookDataAccess();
            BookDataAccess bookDataAccess = new BookDataAccess();
            List<String> bookList = userBookDataAccess.GetUserReadorWantBook(App.UserEmail, readWant);

            int column = 0;
            int row = 0;

            for (int a = 0; a < bookList.Count; a++) {
                Book bookClass = bookDataAccess.GetBookByName(bookList[a]);
                Image bookImage = new Image { HeightRequest = 300, Source = bookClass.BookPhoto };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    ImageTapped(bookImage.Source.ToString().Replace("Uri: ", ""));
                };
                bookImage.GestureRecognizers.Add(tapGestureRecognizer);
                if (column == 0) {
                    if (row != 0) {
                        Console.WriteLine("Added Line " + grid.ToString());
                        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    }
                    grid.Children.Add(bookImage, column, row);
                    column = 1;
                }
                else {
                    grid.Children.Add(bookImage, column, row);
                    column = 0;
                    row++;
                }
            }
        }

        public async void ImageTapped(string bookSource) {
            BookDataAccess bookDataAccess = new BookDataAccess();
            Model.Book bookName = bookDataAccess.GetBookBySource(bookSource);
            await Navigation.PushAsync(new BookPage(bookName.BookName));
        }

        protected override void OnAppearing() {
            var homePage = MainTabbedPage.mainTabbedPage;
            NavigationPage.SetHasNavigationBar(homePage, true);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");

            UserDataAccess userDataAccess = new UserDataAccess();
            User userClass = userDataAccess.GetUserByEmail(App.UserEmail);

            if (userClass.UserPhoto != "" && userClass.UserPhoto != null) {
                if (userClass.UserPhoto.StartsWith("File"))
                    ProfilePhotoImage.Source = userClass.UserPhoto.Replace("File: ", "");
                else
                    ProfilePhotoImage.Source = userClass.UserPhoto.Replace("Uri: ", "");
            }
            UpdateBooks();
        }

        public void UpdateBooks() {
            UserBookDataAccess userBookDataAccess = new UserBookDataAccess();
            UserFriendDataAccess userFriendDataAccess = new UserFriendDataAccess();
            int wantBookCount = userBookDataAccess.GetUserReadorWantCountBook(App.UserEmail, ReadWantEnum.Want);
            int readBookCount = userBookDataAccess.GetUserReadorWantCountBook(App.UserEmail, ReadWantEnum.Read);
            int friendsCount = userFriendDataAccess.CountFriends(App.UserEmail);
            wantLabel.Text = wantBookCount.ToString();
            readLabel.Text = readBookCount.ToString();
            FriendsLabel.Text = friendsCount.ToString();

            if (wantBookCount == 0 && readBookCount == 0) {
                GridStacklayout.IsVisible = false;
                NoBookStacklayout.IsVisible = true;
            }
            else {
                GridStacklayout.IsVisible = true;
                NoBookStacklayout.IsVisible = false;
                wantGrid.Children.Clear();
                readGrid.Children.Clear();
                for (int a = wantGrid.RowDefinitions.Count - 1; a > 0; a--) {
                    wantGrid.RowDefinitions.RemoveAt(a);
                }
                for (int a = readGrid.RowDefinitions.Count - 1; a > 0; a--) {
                    readGrid.RowDefinitions.RemoveAt(a);
                }
                GetAllBooksToProfilePage(wantGrid, ReadWantEnum.Want);
                GetAllBooksToProfilePage(readGrid, ReadWantEnum.Read);
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e) {
            await Navigation.PushAsync(new SeeAllUsers());
        }
    }
}