using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Me
{
	public class LoginViewModel : ViewModel
	{
		UserTableDatabase DB = new UserTableDatabase ();

		public LoginViewModel ()
		{
			Users = DB.GetItems () as List<User>;
		}

		List<User> users;

		public List <User> Users { 
			get { return users; } 
			set { SetProperty (ref users, value); } 
		}

		string email;

		public string Email {
			get{ return email; }
			set{ SetProperty (ref email, value); }
		}

		string password;

		public string Password {
			get{ return password; }
			set{ SetProperty (ref password, value); }
		}

		public ICommand LoginCommand 
		{ get { return new Command (() => { 

				//var admin = DB.GetItem (Email, Password);
				//if (admin != null) {
				//je rentre
				//Application.Current.Properties ["User"] = admin;
				Application.Current.MainPage = new MasterDetailPage {

					Master = new NavigationPage (ViewFactory.Create<HomeViewModel> () as Page) {
						Title = "Master"
					},

					Detail = new NavigationPage (ViewFactory.Create<HomeViewModel> () as Page) {
						Title = "Details"
					},
				};
				//}
			}); } }


		public ICommand NavigateCommand {
			get {
				return new Command (async() => {
					await NavigateToViewModel<HomeViewModel> ();
		
				});
			}
		}

		//		public ICommand NavigateCommand {
		//			get {
		//				return new Command (async() => {
		//					await NavigateToViewModel<SignUpViewModel> ();
		//
		//				});
		//			}
		//		}
	}
}
