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
    public partial class ProfilePage : ContentPage {
        public ProfilePage() {
            InitializeComponent();
            UserDataAccess userDataAccess = new UserDataAccess();
            UserClass userClass = userDataAccess.GetUserByEmail(App.UserEmail);
            userName.Text = userClass.UserName;

            getAllBooksToProfilePage(wantGrid, ReadWant.Want);
            getAllBooksToProfilePage(readGrid, ReadWant.Read);
        }

        public void getAllBooksToProfilePage(Grid grid, ReadWant readWant) {

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            BookDataAccess bookDataAccess = new BookDataAccess();
            List<String> bookList = bookDataAccess.GetUserReadorWantBook(App.UserEmail, readWant);


            int column = 0;
            int row = 0;

            for (int a = 0; a < bookList.Count; a++) {
                BookClass bookClass = bookDataAccess.GetBookByName(bookList[a]);
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                Image bookImage = new Image { HeightRequest = 300, Source = bookClass.bookphoto };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    ImageTapped(bookImage.Source.ToString().Replace("Uri: ", ""));
                };
                bookImage.GestureRecognizers.Add(tapGestureRecognizer);
                if (column == 0) {
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
            BookClass bookName = bookDataAccess.GetBookBySource(bookSource);
            await Navigation.PushAsync(new Book(bookName.BookName));
        }

        protected override void OnAppearing() {
            var homePage = MainTabbedPage.mainTabbedPage;
            NavigationPage.SetHasNavigationBar(homePage, true);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
        }

    }
}