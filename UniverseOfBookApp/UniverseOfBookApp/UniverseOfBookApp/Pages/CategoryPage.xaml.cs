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
    public partial class CategoryPage : ContentPage {
        public CategoryPage() {
            InitializeComponent();
        }

        public CategoryPage(string categoryName) {
            InitializeComponent();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.White;

            NavigationPage.SetTitleView(this, new Label { Text = categoryName, FontSize = 24 });

            categoryGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            categoryGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            categoryGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            categoryGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            BookDataAccess bookDataAccess = new BookDataAccess();
            List<Book> bookClass = bookDataAccess.GetAllBookByCategory((CategoryEnum)Enum.Parse(typeof(CategoryEnum), categoryName.Replace(" ", "")));

            int column = 0;
            int row = 0;

            for (int a = 0; a < bookClass.Count; a++) {
                categoryGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                Image bookImage = new Image { HeightRequest = 300, Source = bookClass[a].BookPhoto };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    ImageTapped(bookImage.Source.ToString().Replace("Uri: ", ""));
                };
                bookImage.GestureRecognizers.Add(tapGestureRecognizer);
                if (column == 0) {
                    categoryGrid.Children.Add(bookImage, column, row);
                    column = 1;
                }
                else {
                    categoryGrid.Children.Add(bookImage, column, row);
                    column = 0;
                    row++;
                }
            }
        }

        public async void ImageTapped(string bookSource) {
            BookDataAccess bookDataAccess = new BookDataAccess();
            Book bookName = bookDataAccess.GetBookBySource(bookSource);
            await Navigation.PushAsync(new BookPage(bookName.BookName));
        }
    }
}