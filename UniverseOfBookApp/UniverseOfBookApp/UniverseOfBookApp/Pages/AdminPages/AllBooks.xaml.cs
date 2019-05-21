using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages.AdminPages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllBooks : ContentPage {
        BookDataAccess bookDataAccess = new BookDataAccess();
        UserBookDataAccess UserBookDataAccess = new UserBookDataAccess();

        public AllBooks() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            List<Model.Book> bookClasses = bookDataAccess.GetAllBook().ToList();
            listView.BindingContext = bookClasses;
        }

        private async void DeleteBook_Clicked(object sender, EventArgs e) {
            var answer = await DisplayAlert("Question?", "Would you like to delete?", "Yes", "No");
            if (answer) {
                Model.Book bookClass = new Model.Book();
                bookClass = (Model.Book)listView.SelectedItem;
                bookDataAccess.DeleteBookName(bookClass.BookName);
            }
            Navigation.InsertPageBefore(new AllBooks(), this);
            await Navigation.PopAsync();
        }

        private async void AllBooksDelete_Clicked(object sender, EventArgs e) {
            var answer = await DisplayAlert("Question?", "Would you like to delete all users ?", "Yes", "No");
            if (answer) {
                bookDataAccess.DeleteAllBook();
            }
        }
    }
}