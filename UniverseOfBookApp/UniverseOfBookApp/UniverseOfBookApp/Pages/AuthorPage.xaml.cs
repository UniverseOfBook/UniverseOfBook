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
    public partial class AuthorPage : ContentPage {
        AuthorDataAccess authorData = new AuthorDataAccess();
        public AuthorPage() {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
        }

        public AuthorPage(string name) {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            Author authorClass = new Author();
            authorClass = authorData.GetAuthorbyName(name);
            AuthorImage.Source = authorClass.AuthorPhoto;
            AuthorInfo.Text = authorClass.AuthorDescription;
            AuthorNAME.Text = authorClass.AuthorName;

            List<Model.Book> BookList = authorData.GetBooks(name);

            for (int i = 0; i < BookList.Count; i++) {
                Image bookImage = new Image { Source = BookList[i].BookPhoto };
                MyStackLayout.Children.Add(bookImage);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    ImageTapped(bookImage.Source.ToString().Replace("Uri: ", ""));
                };
                bookImage.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        private async void SwipedToBack(object sender, SwipedEventArgs e) {
            Console.WriteLine("swipetoback");
            await Navigation.PopAsync();
        }

        public async void ImageTapped(string bookSource) {
            BookDataAccess bookDataAccess = new BookDataAccess();
            Model.Book bookName = bookDataAccess.GetBookBySource(bookSource);
            await Navigation.PushAsync(new BookPage(bookName.BookName));
        }
    }
}