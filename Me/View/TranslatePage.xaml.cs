using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Me
{
	public partial class TranslatePage : ContentPage
	{
		public TranslatePage ()
		{
			InitializeComponent ();
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var viewModel = BindingContext as TranslateViewModel;

			if (viewModel == null) 
				return;
			
			viewModel.NavigateToViewModelDelegate = NavigateToViewModel;
			foreach (string element in viewModel.Dico) {
				Mypicker.Items.Add (element);
				Mypicker1.Items.Add (element);
			}
		}

		async Task<bool> NavigateToViewModel (Type tViewModel, Func<object> viewModelFactory)
		{
			await Navigation.PushAsync ((Page)ViewFactory.Create (tViewModel, () => (ViewModel)viewModelFactory ()));
			//Navigation.RemovePage (this);
			return true;
		}

	}
}