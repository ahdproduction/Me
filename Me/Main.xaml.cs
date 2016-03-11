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
		}

		public Main ()
		{
			InitializeComponent ();

			MainPage = new NavigationPage (ViewFactory.Create<HomeViewModel> () as Page) {
				Title = "HOME"
			};
		}
	}
}

