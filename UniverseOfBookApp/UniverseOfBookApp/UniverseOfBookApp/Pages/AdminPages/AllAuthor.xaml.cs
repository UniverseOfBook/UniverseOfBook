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
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            List<AuthorClass> authorClasses = new List<AuthorClass>();
            authorClasses = authorDataAccess.GetAllAuthor().ToList();
            listView.BindingContext = authorClasses;
            listView.IsRefreshing = false;
        }
        
        private  async void DeleteAuthor_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Would you like to delete?", "Yes", "No");
            if (answer)
            {
                AuthorClass author = new AuthorClass();
               author  = (AuthorClass)listView.SelectedItem;
                authorDataAccess.DeleteAuthorName(author.AuthorName);
                
            }
            Navigation.InsertPageBefore(new AllAuthor(), this);
            await Navigation.PopAsync();

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