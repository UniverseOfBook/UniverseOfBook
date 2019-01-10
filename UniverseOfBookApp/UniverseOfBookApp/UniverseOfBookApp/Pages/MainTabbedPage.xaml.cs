using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage {

        public static MainTabbedPage mainTabbedPage;

        public MainTabbedPage() {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom)
                                                             .SetBarItemColor(Color.FromHex("#6d6d6d"))
                                                             .SetBarSelectedItemColor(Color.FromHex("#c62828"))
                                                             .SetIsLegacyColorModeEnabled(true);

            mainTabbedPage = this;
            var homePage = new HomePage() { Title = "Home", Icon = "homepage" };
            var searchPage = new SearchPage() { Title = "Search", Icon = "magnifier" };
            var activityPage = new ActivityPage() { Title = "Activity", Icon = "booksstack" };
            var profilePage = new ProfilePage() { Title = "Profile", Icon = "user" };

            Children.Add(homePage);
            Children.Add(searchPage);
            Children.Add(activityPage);
            Children.Add(profilePage);
        }

        private async void SettingsClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}