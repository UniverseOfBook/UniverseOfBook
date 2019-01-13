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
    public partial class Book : ContentPage {

        DataAccess.BookDataAccess BookDataAccess = new DataAccess.BookDataAccess();
        DataAccess.AuthorDataAccess author = new DataAccess.AuthorDataAccess();
        DataAccess.UserDataAccess UserDataAccess = new DataAccess.UserDataAccess();


        public Book() {
            InitializeComponent();
        }

        public Book(string name) {
            InitializeComponent();
            BookClass book = BookDataAccess.GetBookByName(name);
            Bookphoto.Source = book.bookphoto;
            Bookname.Text = book.BookName;
            BookDescription.Text = book.Description;
            AuthorName.Text = book.AuthorName;
            AuthorClass authorClass = author.GetAuthorbyName(book.AuthorName);
            AuthorPhoto.Source = authorClass.AuthorPhoto;
        }

        private async void AuthorTapped(object sender, EventArgs e) {
            await Navigation.PushAsync(new Author(AuthorName.Text));
        }

        private void WantButton_Clicked(object sender, EventArgs e)
        {
            UserBook userBook = new UserBook();
            userBook.BookName = Bookname.Text;
            userBook.Email = App.UserEmail;
            userBook.dateTime = DateTime.Now;
            userBook.ReadWant = ReadWant.Want;
            UserBookDataAccess userBookDataAccess = new UserBookDataAccess();
            userBookDataAccess.UserInsert(userBook);

            DisplayAlert("Want Book", "You added this book to want list", "OK");
        }

        private void ReadButton_Clicked(object sender, EventArgs e)
        {
            UserBook userBook = new UserBook();
            userBook.BookName = Bookname.Text;
            userBook.Email = App.UserEmail;
            userBook.dateTime = DateTime.Now;
            userBook.ReadWant = ReadWant.Read;
            UserBookDataAccess userBookDataAccess = new UserBookDataAccess();
            userBookDataAccess.UserInsert(userBook);

            DisplayAlert("Read Book", "You added this book to read list", "OK");
        }
    }
}