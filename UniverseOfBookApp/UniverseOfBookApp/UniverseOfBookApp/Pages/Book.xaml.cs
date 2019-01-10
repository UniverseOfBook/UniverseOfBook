using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Book : ContentPage
	{
		public Book ()
		{
			InitializeComponent ();
		}

        private async void AuthorTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Author());
        }
        
    }
}