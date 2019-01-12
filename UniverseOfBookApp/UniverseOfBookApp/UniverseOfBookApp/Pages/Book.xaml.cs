using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Book : ContentPage
	{

        DataAccess.BookDataAccess BookDataAccess = new DataAccess.BookDataAccess();
        DataAccess.AuthorDataAccess author = new DataAccess.AuthorDataAccess();
		public Book ()
		{
			InitializeComponent ();
		}
        public Book(String name)
        {

           
            InitializeComponent();
            BookClass book = BookDataAccess.GetBookByName(name);
            Bookphoto.Source = book.bookphoto;
            Bookname.Text = book.BookName;
            BookDescription.Text = book.Description;
            AuthorName.Text = book.AuthorName;

            AuthorClass authorClass = author.GetAuthorbyName(book.AuthorName);

            AuthorPhoto.Source = authorClass.AuthorPhoto;

            

            
        }

        private async void AuthorTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Author(AuthorName.Text));
        }

       
    }
}