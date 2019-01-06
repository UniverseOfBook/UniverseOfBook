using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfBookApp.DependencyConnection;
using UniverseOfBookApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniverseOfBookApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{
        private SQLiteConnection connection;
        public User user;
		public SignUp ()
            
		{
            
			InitializeComponent ();
            connection = DependencyService.Get<SqlConnection>().GetConnection();
            connection.CreateTable<User>();
		}

        private void Submit_Clicked(object sender, EventArgs e)
        {
            if (Password.Text.Equals(PasswordAgain) )
            {

                user = new User();
                user.Email = Email.Text;
                user.Password = Password.Text;
                user.UserName = Name.Text;
                user.UserAdmin =UserAdmin.Admin ;
                connection.Insert(user);
                
            }
           
            //user.


        }
    }
}