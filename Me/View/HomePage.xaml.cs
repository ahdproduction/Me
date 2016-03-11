using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Me
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
		}
	}
}

