using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DataAccess;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages.AdminPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Alluser : ContentPage
	{
        public UserDataAccess userDataAccess = new UserDataAccess();
        public UserClass user;

		public Alluser ()
		{
			InitializeComponent ();

            //Click();

            //
            List<UserClass> users = new List<UserClass>();
            
            users = userDataAccess.GetAllUsers().ToList();

            listView.BindingContext = users;
            

        }

        private void DeleteUser_Clicked(object sender, EventArgs e)
        {

        }

        private async void AllUserDelete_Clicked(object sender, EventArgs e)
        {
            
            var answer = await DisplayAlert("Question?", "Would you like to delete all users ?", "Yes", "No");
            if (answer)
            {
              userDataAccess.DeleteAllUser();
            }
            
        }
        //public void Click()
        // {

        //     user = new User();
        // user.Name  = userDataAccess.GetUser(2).Name;
        //     Debug.WriteLine(user.Name);
        // }

    }
}