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
        public UserDataAccess userDataAccess;
        public User user;

		public Alluser ()
		{
			InitializeComponent ();

            //Click();

            //
            List<User> users = new List<User>();
            userDataAccess = new UserDataAccess();
            users = userDataAccess.GetAllUsers().ToList();

            listView.BindingContext = users;
            

        }
       //public void Click()
       // {

       //     user = new User();
       // user.Name  = userDataAccess.GetUser(2).Name;
       //     Debug.WriteLine(user.Name);
       // }

	}
}