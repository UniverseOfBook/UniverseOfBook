﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Author : ContentPage
	{
		public Author ()
		{
			InitializeComponent ();
		}

        private async void SwipedToBack(object sender, SwipedEventArgs e)
        {
            Console.WriteLine("swipetoback");
            await Navigation.PopAsync();
        }
    }
}