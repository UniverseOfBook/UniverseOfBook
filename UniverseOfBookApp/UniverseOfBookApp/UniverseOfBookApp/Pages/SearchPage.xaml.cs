using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
         if(e.NewTextValue != null)
            {
                Searching(e.NewTextValue);
            }
        }
        private void Searching(string text)
        {
            BookClass bookClass = new BookClass();

            bookClass= bookDataAccess.GetBookByName(text);
            search.IsVisible = false;
            Image image = new Image();
            image.Source = bookClass.bookphoto;
            StackL.Children.Add(image);
            

        }
        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
           
        }
    }
}