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
    public partial class HomePage : Xamarin.Forms.ContentPage {
        
        public HomePage() {
            InitializeComponent();

            try {
                BookDataAccess bookDataAccess = new BookDataAccess();
                List<BookClass> allBooks = bookDataAccess.GetAllBook().ToList();

                for (int i = 0; i < allBooks.Count; i++) {
                    string url = allBooks[i].bookphoto;
                    Console.WriteLine(url);
                    Image bookImage = new Image { Source = url };
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
    }
}