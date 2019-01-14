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
        UserBookDataAccess UserBookDataAccess = new UserBookDataAccess();


        public Book() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
        }

        public Book(string name) {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
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

        private void Button_Clicked(object sender, EventArgs e) {
            Button button = (Button)sender;
            BookDataAccess bookDataAccess = new BookDataAccess();
            BookClass bookClass = bookDataAccess.GetBookBySource(Bookphoto.Source.ToString().Replace("Uri: ", ""));
            List<UserBook> userBooks = UserBookDataAccess.GetBookByEmailAndBookName(App.UserEmail, bookClass.BookName);

            if (userBooks.Count != 0) {
                if (userBooks[0].ReadWant == ReadWant.Want) {
                    if (button.Text == "Read") {
                        userBooks[0].ReadWant = ReadWant.Read;
                        userBooks[0].dateTime = DateTime.Now;
                        UserBookDataAccess.BookUserUpdateReadOrWant(userBooks[0]);
                        DisplayAlert("Read Book", "You added this book to Read List", "Ok");
                    }
                    else {
                        DisplayAlert("Warning", "You already add this book in your Want List", "Ok");
                    }
                }
                else {
                    if (button.Text == "Want") {
                        userBooks[0].ReadWant = ReadWant.Want;
                        userBooks[0].dateTime = DateTime.Now;
                        UserBookDataAccess.BookUserUpdateReadOrWant(userBooks[0]);
                        DisplayAlert("Want Book", "You added this book to Want List", "Ok");
                    }
                    else {
                        DisplayAlert("Warning", "You already add this book in your Read List", "Ok");
                    }
                }
            }
            else {
                UserBook userBook = new UserBook();
                userBook.BookName = Bookname.Text;
                userBook.Email = App.UserEmail;
                userBook.dateTime = DateTime.Now;
                if (button.Text == "Want") {
                    DisplayAlert("Want Book", "You added this book to Want List", "Ok");
                    userBook.ReadWant = ReadWant.Want;
                }
                else {
                    DisplayAlert("Read Book", "You added this book to Read List", "Ok");
                    userBook.ReadWant = ReadWant.Read;
                }
                UserBookDataAccess.UserInsert(userBook);
            }
        }
    }
}