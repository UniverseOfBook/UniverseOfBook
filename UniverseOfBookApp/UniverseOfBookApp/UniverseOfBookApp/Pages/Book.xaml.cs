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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<UserBook> userBooks = UserBookDataAccess.GetAllBookUser(App.UserEmail);

            for (int i = 0; i < userBooks.Count; i++)
            {
                 if (userBooks[i].BookName == Bookname.Text)
                {
                    if(userBooks[i].ReadWant==ReadWant.Want)
                    {
                        if (button.Text == "Read") { 
                        userBooks[i].ReadWant = ReadWant.Read;
                        userBooks[i].dateTime = DateTime.Now;
                        UserBookDataAccess.BookUserUpdate(userBooks[i]);
                        }
                        else
                        {
                            DisplayAlert("Warning", "You already add this book in your Want List", "Ok");
                            break;
                        }
                    }
                    else
                    {
                        if (button.Text == "Want")
                        {
                            userBooks[i].ReadWant = ReadWant.Want;
                            userBooks[i].dateTime = DateTime.Now;
                            UserBookDataAccess.BookUserUpdate(userBooks[i]);
                        }
                        else
                        {
                            DisplayAlert("Warning", "You already add this book in your Read List", "Ok");
                            break;
                        }
                    }

                }
                else
                {
                    UserBook userBook = new UserBook();
                    userBook.BookName = Bookname.Text;
                    userBook.Email = App.UserEmail;
                    userBook.dateTime = DateTime.Now;
                    if (button.Text == "Want")
                        userBook.ReadWant = ReadWant.Want;
                    else
                        userBook.ReadWant = ReadWant.Read;
                    UserBookDataAccess.UserInsert(userBook);
                }
                

            }
          
         
        }

        
    }
}