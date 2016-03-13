using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Me
{
	public class TranslateViewModel : ViewModel
	{
		public TranslateViewModel ()
		{
		}

		string contentText;

		public string ContentText {
			get{ return contentText; }
			set{ SetProperty (ref contentText, value); }
		}

		string contentTranslate;

		public string ContentTranslate {
			get{ return contentTranslate; }
			set{ SetProperty (ref contentTranslate, value); }
		}

		string language;

		public string Language {
			get{ return language; }
			set{ SetProperty (ref language, value); }
		}



		public ICommand Translate {
			get {
				return new Command (async (T) => {

					TranslateService traduire = new TranslateService ();
					ContentTranslate = await traduire.TranslateAsync (ContentText, Language);

				});
			}
		}



	}
}

