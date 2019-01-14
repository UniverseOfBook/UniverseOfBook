﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages.AdminPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminPage : ContentPage
	{
		public AdminPage ()
		{
			InitializeComponent ();
		}

        private async void AddBook_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddBook());
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            App.UserEmail = "";
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private async void  AddAuthor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAuthor());
        }

        private async void SeeUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Alluser());
        }

        private async void SeeBook_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllBooks());
        }

        private async void SeeAuthor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllAuthor());
        }
    }
}