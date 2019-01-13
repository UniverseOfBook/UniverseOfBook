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
	public partial class AllBooks : ContentPage
	{

        BookDataAccess bookDataAccess = new BookDataAccess();
        UserBookDataAccess UserBookDataAccess = new UserBookDataAccess();
        
		public AllBooks ()
		{
			InitializeComponent ();
            List<BookClass> bookClasses = new List<BookClass>();
            bookClasses = bookDataAccess.GetAllBook().ToList();
            listView.BindingContext = bookClasses;
            
        }

        private async void DeleteBook_Clicked(object sender, EventArgs e)
        {
           
            var answer = await DisplayAlert("Question?", "Would you like to delete?", "Yes", "No");
            if (answer)
            {
              BookClass bookClass = new BookClass();
            bookClass = (BookClass)listView.SelectedItem;
            bookDataAccess.DeleteBookName(bookClass.BookName);
             List<UserBook> userBooks=UserBookDataAccess.GetUserBook(bookClass.BookName, App.UserEmail);
                for (int i = 0; i < userBooks.Count; i++)
                {
                    UserBookDataAccess.DeleteBookName(userBooks[i]);
                }

            }
            Navigation.InsertPageBefore(new AllBooks(), this);
            await Navigation.PopAsync();

        }

        private async void AllBooksDelete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Would you like to delete all users ?", "Yes", "No");
            if (answer)
            {
                bookDataAccess.DeleteAllBook();
            }
        }
    }
}