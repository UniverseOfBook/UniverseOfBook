using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage {
        DataAccess.BookDataAccess bookDataAccess = new BookDataAccess();
        public SearchPage() {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            var mainTabbedPage = MainTabbedPage.mainTabbedPage;
            if (mainTabbedPage != null)
                NavigationPage.SetHasNavigationBar(mainTabbedPage, false);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) {
            if (e.NewTextValue != null && e.NewTextValue.Length > 3) {
                Searching(e.NewTextValue);
            }
            else {
                StackL.Children.Clear();
                searchImages.Clear();
                search.IsVisible = true;
            }
        }

        private List<string> searchImages = new List<string>();
        private void Searching(string text) {
            List<string> bookNames = bookDataAccess.GetAllBooksName();
            List<string> suggestionList = bookNames.Where(book => book.ToLower().Contains(text.ToLower())).ToList();

            List<Book> suggestedBooks = new List<Book>();

            if (suggestionList.Count == 0) {
                searchImages.Clear();
                search.IsVisible = true;
                return;
            }

            foreach (string suggestion in suggestionList) {
                Book book = bookDataAccess.GetBookByName(suggestion);
                suggestedBooks.Add(book);
            }
            
            search.IsVisible = false;
            foreach (Book suggestedBook in suggestedBooks) {
                if (searchImages.Contains(suggestedBook.BookName))
                    continue;
                else
                    searchImages.Add(suggestedBook.BookName);

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (sender, e) => {
                    Image image1 = (Image)sender;
                    BookDataAccess bookDataAccess = new BookDataAccess();
                    Book bookName = bookDataAccess.GetBookBySource(image1.Source.ToString().Replace("Uri: ", ""));
                    await Navigation.PushAsync(new BookPage(bookName.BookName));
                };
                Image image = new Image {
                    HeightRequest = 300,
                    Source = suggestedBook.BookPhoto
                };
                image.GestureRecognizers.Add(tapGestureRecognizer);
                StackL.Children.Add(image);
            }
        }
    }
}