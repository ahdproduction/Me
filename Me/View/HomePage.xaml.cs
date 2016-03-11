using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Me
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
			//NavigationPage.SetHasNavigationBar (this, false);
		}

		protected override void OnBindingContextChanged ()
		{
			var viewModel = BindingContext as HomeViewModel;
			if (viewModel == null)
				return;
			viewModel.NavigateToViewModelDelegate = NavigateToViewModel;
			viewModel.NavigateBackDelegate = NavigateBack;
		}

		async Task<bool> NavigateToViewModel (Type tViewModel, Func<object> viewModelFactory)
		{
			await Navigation.PushAsync ((Page)ViewFactory.Create (tViewModel, () => (ViewModel)viewModelFactory ()));
			//Navigation.RemovePage (this);
			return true;
		}

		public async Task<bool> NavigateBack ()
		{
			await Navigation.PopAsync ();			
			return true;
		}
	}

}

