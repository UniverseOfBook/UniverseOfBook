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
	public partial class Author : ContentPage
	{
        DataAccess.AuthorDataAccess authorData = new DataAccess.AuthorDataAccess();
        DataAccess.BookDataAccess BookDataAccess = new DataAccess.BookDataAccess();
		public Author ()
		{
            InitializeComponent();

        }

        public Author(string name)
        {

            InitializeComponent();
            AuthorClass authorClass = new AuthorClass();
            authorClass = authorData.GetAuthorbyName(name);
            AuthorImage.Source = authorClass.AuthorPhoto;
            AuthorInfo.Text = authorClass.AuthorDescription;
            AuthorNAME.Text = authorClass.AuthorName;
            
            List<BookClass> BookList = authorData.GetBooks(name);


            for (int i = 0; i < BookList.Count; i++)
            {

                Image bookImage = new Image { Source = BookList[i].bookphoto };
                MyStackLayout.Children.Add(bookImage);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    ImageTapped(BookList[i].BookName);
                };
                bookImage.GestureRecognizers.Add(tapGestureRecognizer);

            }
           
           
        }
        private async void SwipedToBack(object sender, SwipedEventArgs e)
        {
            Console.WriteLine("swipetoback");
            await Navigation.PopAsync();
        }

        public async void ImageTapped(string bookname)
        {
            await Navigation.PushAsync(new Book(bookname));

        }
    }
}