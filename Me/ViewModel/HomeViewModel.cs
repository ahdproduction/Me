using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Me
{
	public class HomeViewModel : ViewModel
	{
		public HomeViewModel ()
		{
		}

		public ICommand NavigateToTranslateCommand {
			get {
				return new Command (async() => {
					await NavigateToViewModel<TranslateViewModel> ();

				});
			}
		}

	}
}

