using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBook : ContentPage
    {
        BookDataAccess bookDataAccess = new BookDataAccess();
        AuthorDataAccess AuthorData = new AuthorDataAccess();
        public AddBook()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            List<String> authors = new List<String>();
            authors = AuthorData.Authors();
            for(int i = 0; i < authors.Count; i++)
            {
                AuthorPick.Items.Add(authors[i]);
            }
            
        }

        private async void Authors_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllAuthor());
        }

        private async void Users_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Alluser());
                
        }

        private async void Books_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllBooks());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            BookClass book = new BookClass();
            book.AuthorName = AuthorPick.SelectedItem.ToString();
            book.PageNumber =Convert.ToInt32(PageNumber.Text);
            book.PublishDate = PublishDate.Date;
            string publish= PublishPick.SelectedItem.ToString();
            book.BookName = BookName.Text;
           CategoryEnum category=(CategoryEnum) Enum.Parse(typeof(CategoryEnum),CategoryPick.SelectedItem.ToString().Replace(" ", ""));
            Publishers publishers = (Publishers)Enum.Parse(typeof(Publishers), PublishPick.SelectedItem.ToString().Replace(" ", ""));
            book.Category = category;
            book.Publishers = publishers;
            book.bookphoto = BookPhoto.Text;
         int addingbook=bookDataAccess.BookInsert(book);
            if (addingbook > 0)
            {
                DisplayAlert("ADD", "Book was add", "OK");

                BookName.Text = "";
                AuthorPick.SelectedItem = null;
                PublishDate.Date = DateTime.Now;
                PublishPick.SelectedItem = null;
                CategoryPick.SelectedItem = null;

            }
            else
            {
                DisplayAlert("ADD", "Book wasn't add", "OK");
            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}