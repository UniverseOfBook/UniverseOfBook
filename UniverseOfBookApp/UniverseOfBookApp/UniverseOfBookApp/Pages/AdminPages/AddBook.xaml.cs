using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages.AdminPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBook : ContentPage
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private async void Authors_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllAuthor());
        }

        private async void Users_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Alluser());
                
        }

        private async void Books_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllBooks());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}