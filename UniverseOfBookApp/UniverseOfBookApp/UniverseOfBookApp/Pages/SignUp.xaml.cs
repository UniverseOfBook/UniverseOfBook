using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{

        public UserDataAccess UserDataAccess;
        public User user;
        

		public SignUp ()
		{
			InitializeComponent ();
           
		}

        private void Submit_Clicked(object sender, EventArgs e)
        {
            //We create new user here 
            if(Password.Text ==PasswordAgain.Text && Email.Text !=null && Name.Text != null) { 
                user = new User();
                UserDataAccess = new UserDataAccess();   

                user.Email = Email.Text;
                user.Password = Password.Text;
                user.UserName = Name.Text;
                user.UserAdmin = UserAdmin.User;
                UserDataAccess.UserInsert(user);
                
                DisplayAlert("Join", "Thanks for Joining us "+Name.Text, "Cancel");
           }
        }

        private async void BackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}