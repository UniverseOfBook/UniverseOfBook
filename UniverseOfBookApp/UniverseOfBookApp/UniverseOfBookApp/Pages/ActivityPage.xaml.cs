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

    public partial class ActivityPage : ContentPage {
        UserFriendDataAccess userFriendataAccess = new UserFriendDataAccess();
        UserBookDataAccess userBookDataAccess = new UserBookDataAccess();
        BookDataAccess bookDataAccess = new BookDataAccess();

        public ActivityPage() {
            InitializeComponent();
            UpdatePage();
        }

        public async void ImageTapped(string bookSource) {
            Book bookName = bookDataAccess.GetBookBySource(bookSource);
            await Navigation.PushAsync(new BookPage(bookName.BookName));
        }

        protected override void OnAppearing() {
            var homePage = MainTabbedPage.mainTabbedPage;
            NavigationPage.SetHasNavigationBar(homePage, false);
            MyStackLayout.Children.Clear();
            UpdatePage();
        }

        public void AddingActivity(List<UserBook> userBooks, string email) {
            for (int i = 0; i < userBooks.Count; i++) {
                Frame frame = new Frame() { CornerRadius = 10 };
                Book book = bookDataAccess.GetBookByName(userBooks[i].BookName);
                StackLayout stackLayout = new StackLayout();
                UserDataAccess userDataAccess = new UserDataAccess();
                User user = userDataAccess.GetUserByEmail(email);

                Label label1 = new Label() { FontSize = 18, HorizontalOptions = LayoutOptions.Start };
                label1.Text = "Time added: " + userBooks[i].DateTime.ToString("dd/MM/yyyy");
                stackLayout.Children.Add(label1);

                Label label = new Label() { FontSize = 20, HorizontalOptions = LayoutOptions.Start };
                if ((userBooks[i].ReadWant).ToString() == "Read") {
                    label.Text = user.UserName + " want to read this book";
                }
                else {
                    label.Text = user.UserName + " want this book";
                }

                stackLayout.Children.Add(label);

                Image bookImage = new Image { Source = book.BookPhoto, HorizontalOptions = LayoutOptions.Start };
                stackLayout.Children.Add(bookImage);

                frame.Content = stackLayout;
                MyStackLayout.Children.Add(frame);

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    ImageTapped(bookImage.Source.ToString().Replace("Uri: ", ""));
                };
                bookImage.GestureRecognizers.Add(tapGestureRecognizer);

            }
        }

        public void UpdatePage() {
            List<UserFriends> users = userFriendataAccess.GetAllFriends(App.UserEmail);
            for (int i = 0; i < users.Count; i++) {
                List<UserBook> friendBooks = userBookDataAccess.GetAllBookUser(users[i].FriendEmail);
                AddingActivity(friendBooks, users[i].FriendEmail);
            }
            List<UserBook> userBooks = userBookDataAccess.GetAllBookUser(App.UserEmail);

            AddingActivity(userBooks, App.UserEmail);
        }
    }
}