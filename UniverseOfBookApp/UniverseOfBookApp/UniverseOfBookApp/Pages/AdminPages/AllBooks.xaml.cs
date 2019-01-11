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
        
		public AllBooks ()
		{
			InitializeComponent ();
            List<BookClass> bookClasses = new List<BookClass>();
            bookClasses = bookDataAccess.GetAllBook().ToList();
            listView.BindingContext = bookClasses;
		}

        private void DeleteBook_Clicked(object sender, EventArgs e)
        {

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