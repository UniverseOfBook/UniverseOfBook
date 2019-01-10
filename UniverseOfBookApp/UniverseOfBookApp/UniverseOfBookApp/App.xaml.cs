using System;
using UniverseOfBookApp.Pages;
using UniverseOfBookApp.Pages.AdminPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UniverseOfBookApp
{
    public partial class App : Application
    {
        public App()
        {
            Console.WriteLine("Started");
            InitializeComponent();

<<<<<<< HEAD
            MainPage = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.Transparent,
                BarTextColor = Color.FromHex("#1b1b1b")
            };
=======
            MainPage = new NavigationPage(new LoginPage());
>>>>>>> 07f7b2bea302560195f9e4389db3dd3b7f76082c
        }
        //public static Page GetPage()
        //{
        //    return new NavigationPage(new AddBook());
        //}
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
