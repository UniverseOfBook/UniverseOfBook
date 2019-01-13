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

        DataAccess.UserBookDataAccess UserBookDataAccess = new DataAccess.UserBookDataAccess();
        DataAccess.BookDataAccess BookDataAccess = new DataAccess.BookDataAccess();
        BookClass book;
        public ActivityPage() {
            InitializeComponent();
            List<UserBook> userBooks = UserBookDataAccess.GetAllBookUser(App.UserEmail);
            for (int i = 0; i < userBooks.Count; i++)
            {
                
                book = BookDataAccess.GetBookByName(userBooks[i].BookName);
                Label label = new Label();
                label.Text = (userBooks[i].ReadWant).ToString();
                MyStackLayout.Children.Add(label);
                Label label1 = new Label();
                label1.Text = book.BookName;
                MyStackLayout.Children.Add(label1);
                Image bookImage = new Image { Source = book.bookphoto };
                MyStackLayout.Children.Add(bookImage);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    ImageTapped(bookImage.Source.ToString().Replace("Uri: ", ""));
                };
                bookImage.GestureRecognizers.Add(tapGestureRecognizer);


            }

        }
        public async void ImageTapped(string bookSource)
        {
           
            BookClass bookName = BookDataAccess.GetBookBySource(bookSource);
            await Navigation.PushAsync(new Book(bookName.BookName));
        }
        protected override void OnAppearing() {
            var homePage = MainTabbedPage.mainTabbedPage;
            NavigationPage.SetHasNavigationBar(homePage, false);
        }
    }
}