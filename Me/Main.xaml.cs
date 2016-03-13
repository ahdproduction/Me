using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Me
{
	public partial class Main : Application
	{
		static Main ()
		{
			ViewFactory.Register<HomePage, HomeViewModel> ();
			ViewFactory.Register<LoginPage, LoginViewModel> ();
			ViewFactory.Register<TranslatePage, TranslateViewModel> ();
		}

		public Main ()
		{
			InitializeComponent ();

			MainPage = new NavigationPage (ViewFactory.Create<LoginViewModel> () as Page) {
				Title = "HOME"
			};
		}
	}
}

