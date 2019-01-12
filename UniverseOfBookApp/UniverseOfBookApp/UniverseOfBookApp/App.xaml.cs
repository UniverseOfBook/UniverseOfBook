using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.IO;
using UniverseOfBookApp.Pages;
using UniverseOfBookApp.Pages.AdminPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UniverseOfBookApp {
    public partial class App : Application {

        private static ISettings AppSettings => CrossSettings.Current;

        public static string UserEmail {
            get => AppSettings.GetValueOrDefault(nameof(UserEmail), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserEmail), value);
        }

        public App() {
            Console.WriteLine("Started");
            InitializeComponent();

            if (UserEmail == "") {
                MainPage = new NavigationPage(new LoginPage()) {
                    BarBackgroundColor = Color.FromHex("#efefef"),
                    BarTextColor = Color.FromHex("#1b1b1b")
                };
            }
            else {
                MainPage = new NavigationPage(new MainTabbedPage()) {
                    BarBackgroundColor = Color.FromHex("#efefef"),
                    BarTextColor = Color.FromHex("#1b1b1b")
                };
            }

            //MainPage = new NavigationPage(new LoginPage());
        }


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
