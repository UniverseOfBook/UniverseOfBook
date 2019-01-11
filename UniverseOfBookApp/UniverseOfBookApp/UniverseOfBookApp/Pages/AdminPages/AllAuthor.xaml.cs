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
	public partial class AllAuthor : ContentPage
	{
        AuthorDataAccess authorDataAccess = new AuthorDataAccess();

		public AllAuthor ()
		{
			InitializeComponent ();
            List<AuthorClass> authorClasses = new List<AuthorClass>();
            authorClasses = authorDataAccess.GetAllAuthor().ToList();
            listView.BindingContext = authorClasses;
		}
        
        private  async void DeleteAuthor_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Would you like to delete?", "Yes", "No");
            if (answer)
            {
                authorDataAccess.DeleteAllAuthor();
            }
        }

        private async void AllAuthorDelete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Would you like to delete all Authors ?", "Yes", "No");
            if (answer)
            {
                authorDataAccess.DeleteAllAuthor();
            }
        }
    }
}