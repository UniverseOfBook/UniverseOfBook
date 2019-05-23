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
            foreach (UserBook userBook in userBooks) {
                Frame frame = new Frame() { CornerRadius = 10 };
                Book book = bookDataAccess.GetBookByName(userBook.BookName);
                StackLayout stackLayoutRight = new StackLayout();
                StackLayout stackLayoutLeft = new StackLayout();
                UserDataAccess userDataAccess = new UserDataAccess();
                User user = userDataAccess.GetUserByEmail(email);

                stackLayoutLeft.Children.Add(new ImageCircle.Forms.Plugin.Abstractions.CircleImage() {
                    Source = user.UserPhoto.Replace("Uri: ", ""),
                    HeightRequest = 50
                });

                var formattedString = new FormattedString();
                formattedString.Spans.Add(new Span { Text = user.UserName, FontAttributes = FontAttributes.Bold, FontSize=20 });

                if ((userBook.ReadWant).ToString() == "Read") {
                    formattedString.Spans.Add(new Span { Text = " read this book" });
                }
                else {
                    formattedString.Spans.Add(new Span { Text = " want this book" });
                }

                stackLayoutRight.Children.Add(new Label {
                    FormattedText = formattedString,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.Start
                });

                Label timeLabel = new Label() { FontSize = 15, HorizontalOptions = LayoutOptions.Start };
                timeLabel.Text = "Time added: " + userBook.DateTime.ToString("dd/MM/yyyy");
                stackLayoutRight.Children.Add(timeLabel);

                Image bookImage = new Image { Source = book.BookPhoto, HorizontalOptions = LayoutOptions.Start };
                stackLayoutRight.Children.Add(bookImage);

                StackLayout stackLayout = new StackLayout() {
                    Orientation = StackOrientation.Horizontal
                };
                stackLayout.Children.Add(stackLayoutLeft);
                stackLayout.Children.Add(stackLayoutRight);

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