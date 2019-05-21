using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage {
        public HomePage() {
            InitializeComponent();
            try {
                BookDataAccess bookDataAccess = new BookDataAccess();
                List<Book> allBooks = bookDataAccess.GetAllBook().ToList();

                for (int i = 0; i < allBooks.Count; i++) {
                    string url = allBooks[i].Bookphoto;
                    Image bookImage = new Image { Source = url };
                    var tapGestureRecognizer = new TapGestureRecognizer();

                    tapGestureRecognizer.Tapped += (s, e) => {
                        ImageTapped(bookImage.Source.ToString().Replace("Uri: ", ""));
                    };
                    bookImage.GestureRecognizers.Add(tapGestureRecognizer);
                    BooksStacklayout.Children.Add(bookImage);
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void CategoryButtonClicked(object sender, EventArgs e) {
            Xamarin.Forms.Button button = (Xamarin.Forms.Button)sender;
            await Navigation.PushAsync(new CategoryPage(button.Text));
        }

        protected override void OnAppearing() {
            var homePage = MainTabbedPage.mainTabbedPage;
            if (homePage != null)
                NavigationPage.SetHasNavigationBar(homePage, false);
        }

        public async void ImageTapped(string bookSource) {
            BookDataAccess bookDataAccess = new BookDataAccess();
            Model.Book bookName = bookDataAccess.GetBookBySource(bookSource);
            await Navigation.PushAsync(new BookPage(bookName.BookName));
        }
    }
}