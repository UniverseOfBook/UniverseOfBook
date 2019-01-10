using System;
using UniverseOfBookApp.Pages;
using UniverseOfBookApp.Pages.AdminPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UniverseOfBookApp {
    public partial class App : Application {
        public App() {
            Console.WriteLine("Started");
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage()) {
                BarBackgroundColor = Color.FromHex("#efefef"),
                BarTextColor = Color.FromHex("#1b1b1b")
            };
        }

        //public static Page GetPage()
        //{
        //    return new NavigationPage(new AddBook());
        //}

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
