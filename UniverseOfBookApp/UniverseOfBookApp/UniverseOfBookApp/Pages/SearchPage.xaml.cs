using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage {
        public SearchPage() {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            var mainTabbedPage = MainTabbedPage.mainTabbedPage;
            if (mainTabbedPage != null)
                NavigationPage.SetHasNavigationBar(mainTabbedPage, false);
        }
    }
}