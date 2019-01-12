using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : Xamarin.Forms.ContentPage {
        
        public HomePage() {
            InitializeComponent();

            DataAccess.BookDataAccess bookDataAccess = new DataAccess.BookDataAccess();
            List<Model.BookClass> allBooks = bookDataAccess.GetAllBook().ToList();

            for (int i = 0; i < allBooks.Count; i++) {
                string url = allBooks[i].bookphoto;
                Console.WriteLine(url);
                Image bookImage = new Image { Source=url };
                BooksStacklayout.Children.Add(bookImage);
            }
        }

        protected override void OnAppearing() {
            var homePage = MainTabbedPage.mainTabbedPage;
            if (homePage != null)
                NavigationPage.SetHasNavigationBar(homePage, false);
        }
    }
}