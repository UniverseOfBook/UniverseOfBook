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
    public partial class AddAuthor : ContentPage {
        AuthorDataAccess DataAccess = new AuthorDataAccess();
        public AddAuthor() {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#efefef");
        }
        private void AddButton_Clicked(object sender, EventArgs e) {
            Model.Author author = new Model.Author {
                AuthorDate = Date.Date,
                AuthorName = AuthorName.Text,
                AuthorDescription = AuthorInfo.Text,
                AuthorPhoto = AuthorPhoto.Text
            };

            int i = DataAccess.AuthorInsert(author);
            if (i > 0) {
                DisplayAlert("ADD", "Author was add", "OK");

                AuthorName.Text = "";
                AuthorInfo.Text = "";
            }
            else {
                DisplayAlert("ADD", "Author wasn't add", "OK");
            }

        }
        private void BackButton_Clicked(object sender, EventArgs e) {

        }
    }
}