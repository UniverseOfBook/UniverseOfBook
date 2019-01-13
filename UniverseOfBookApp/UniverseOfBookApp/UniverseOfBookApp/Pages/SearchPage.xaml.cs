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

        DataAccess.BookDataAccess bookDataAccess = new DataAccess.BookDataAccess();
        public SearchPage() {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            var mainTabbedPage = MainTabbedPage.mainTabbedPage;
            if (mainTabbedPage != null)
                NavigationPage.SetHasNavigationBar(mainTabbedPage, false);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) {
            if (e.NewTextValue != null) {
                Searching(e.NewTextValue);
            }
        }

        private void Searching(string text) {
            BookClass bookClass = new BookClass();
            bookClass = bookDataAccess.GetBookByName(text);
            if (bookClass == null) {
                searchImage.IsVisible = false;
                search.IsVisible = true;
                return;
            }
            search.IsVisible = false;
            searchImage.Source = bookClass.bookphoto;
            searchImage.IsVisible = true;
        }

        private async void ImageTapped(object sender, EventArgs e) {
            Image image1 = (Image)sender;
            BookDataAccess bookDataAccess = new BookDataAccess();
            BookClass bookName = bookDataAccess.GetBookBySource(image1.Source.ToString().Replace("Uri: ", ""));
            await Navigation.PushAsync(new Book(bookName.BookName));
        }
    }
}