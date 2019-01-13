using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class ActivityPage : ContentPage {

        DataAccess.UserBookDataAccess UserBookDataAccess = new DataAccess.UserBookDataAccess();
        public ActivityPage() {
            InitializeComponent();


        }

        protected override void OnAppearing() {
            var homePage = MainTabbedPage.mainTabbedPage;
            NavigationPage.SetHasNavigationBar(homePage, false);
        }
    }
}