using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ActivityPage : ContentPage {
        DataAccess.UserFriendDataAccess userFriendataAccess = new DataAccess.UserFriendDataAccess();
        DataAccess.UserBookDataAccess UserBookDataAccess = new DataAccess.UserBookDataAccess();
        DataAccess.BookDataAccess BookDataAccess = new DataAccess.BookDataAccess();
        Book book;
        Frame frame = new Frame() { CornerRadius = 10 };
        StackLayout stackLayout = new StackLayout();
        public ActivityPage() {
            InitializeComponent();
            UpdatePage();
        }

        public async void ImageTapped(string bookSource) {
            Book bookName = BookDataAccess.GetBookBySource(bookSource);
            await Navigation.PushAsync(new BookPage(bookName.BookName));
        }

        protected override void OnAppearing() {
            var homePage = MainTabbedPage.mainTabbedPage;
            NavigationPage.SetHasNavigationBar(homePage, false);
            MyStackLayout.Children.Clear();
            UpdatePage();
        }
        public void addingActivity(List<UserBook> userBooks,string email) {
            for (int i = 0; i < userBooks.Count; i++) {
                book = BookDataAccess.GetBookByName(userBooks[i].BookName);

                Label label1 = new Label() { FontSize = 18, HorizontalOptions = LayoutOptions.Start };
                label1.Text = "Time added: " + userBooks[i].DateTime.ToString("dd/MM/yyyy");
                stackLayout.Children.Add(label1);

                Label label = new Label() { FontSize = 20, HorizontalOptions = LayoutOptions.Start };
                if ((userBooks[i].ReadWant).ToString() == "Read") {
                    label.Text = "Want to read this book";
                }
                else {
                    label.Text = "Want this book";
                }

                stackLayout.Children.Add(label);

                Image bookImage = new Image { Source = book.BookPhoto, HorizontalOptions = LayoutOptions.Start };
                stackLayout.Children.Add(bookImage);

               

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    ImageTapped(bookImage.Source.ToString().Replace("Uri: ", ""));
                };
                bookImage.GestureRecognizers.Add(tapGestureRecognizer);
                
            }
        }

        public void UpdatePage() {
            

            List<UserFriends> users = userFriendataAccess.GetAllFriends(App.UserEmail);
            for(int i = 0; i < users.Count; i++) {
                List<UserBook> friendBooks = UserBookDataAccess.GetAllBookUser(users[i].FriendEmail);
                addingActivity(friendBooks, users[i].FriendEmail);
            }
              List<UserBook> userBooks = UserBookDataAccess.GetAllBookUser(App.UserEmail);
              
               addingActivity(userBooks,App.UserEmail);
               
              


        }

        public void UpdatePage() {
            List<UserFriends> users = userFriendataAccess.GetAllFriends(App.UserEmail);
            for(int i = 0; i < users.Count; i++) {
                List<UserBook> friendBooks = UserBookDataAccess.GetAllBookUser(users[i].FriendEmail);
                addingActivity(friendBooks);
            }
            List<UserBook> userBooks = UserBookDataAccess.GetAllBookUser(App.UserEmail);
            addingActivity(userBooks);

            frame.Content = stackLayout;
            MyStackLayout.Children.Add(frame);
        }
    }
}