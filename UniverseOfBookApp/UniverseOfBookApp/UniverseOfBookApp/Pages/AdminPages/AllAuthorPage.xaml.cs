using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages.AdminPages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllAuthorPage : ContentPage {
        AuthorDataAccess authorDataAccess = new AuthorDataAccess();

        public AllAuthorPage() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
            List<Model.Author> authorClasses = authorDataAccess.GetAllAuthor().ToList();
            listView.BindingContext = authorClasses;
            listView.IsRefreshing = false;
        }

        private async void DeleteAuthor_Clicked(object sender, EventArgs e) {
            var answer = await DisplayAlert("Question?", "Would you like to delete?", "Yes", "No");
            if (answer) {
                Author author = (Author)listView.SelectedItem;
                authorDataAccess.DeleteAuthorName(author.AuthorName);
            }
            Navigation.InsertPageBefore(new AllAuthorPage(), this);
            await Navigation.PopAsync();
        }

        private async void AllAuthorDelete_Clicked(object sender, EventArgs e) {
            var answer = await DisplayAlert("Question?", "Would you like to delete all Authors ?", "Yes", "No");
            if (answer) {
                authorDataAccess.DeleteAllAuthor();
            }
        }
    }
}