using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Me
{
	public class TranslateViewModel : ViewModel
	{
		public TranslateViewModel ()
		{
			InitializeLanguageList ();
		}


		List<string> dico;
		public List<string> Dico {
			get{ return dico; }
			set{ SetProperty (ref dico, value); }
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


		int selectedIndex1 = -1;

		public int SelectedIndex1 {
			get{ return selectedIndex1; }
			set{ SetProperty (ref selectedIndex1, value); }
		}

		int selectedIndex2 = -1;

		public int SelectedIndex2 {
			get{ return selectedIndex2; }
			set{ SetProperty (ref selectedIndex2, value); }
		}

		string languagePickerSource;

		public string LanguagePickerSource {
			get{ return languagePickerSource; }
			set{ SetProperty (ref languagePickerSource, value); }
		}

		string languagePickerTranslate;

		public string LanguagePickerTranslate {
			get{ return languagePickerTranslate; }
			set{ SetProperty (ref languagePickerTranslate, value); }
		}

		void InitializeLanguageList ()
		{
			Dico = new List<string> ();
			Dico.Add ("Afrikaans");
			Dico.Add ("Albanian");
			Dico.Add ("Arabic");
			Dico.Add ("French");
			Dico.Add ("Dutch");
			Dico.Add ("English");
			Dico.Add ("Russian");
			Dico.Add ("German");
			Dico.Add ("Turkish");
		}

		void SwitchSelectLanguage ()
		{
			switch (SelectedIndex1) {
			case 0:
				LanguagePickerTranslate = "af";
				break;
			case 1:
				LanguagePickerTranslate = "sq";
				break;
			case 2:
				LanguagePickerTranslate = "ar";
				break;
			case 3:
				LanguagePickerTranslate = "fr";
				break;
			case 4:
				LanguagePickerTranslate = "nl";
				break;
			case 5:
				LanguagePickerTranslate = "en";
				break;
			case 6:
				LanguagePickerTranslate = "ru";
				break;
			case 7:
				LanguagePickerTranslate = "de";
				break;
			case 8:
				LanguagePickerTranslate = "tr";
				break;
			default:
				LanguagePickerTranslate = "Select a language please";
				break;
			}

//					switch (SelectedIndex2) {
//					case 0:
//						LanguagePickerSource = "af";
//						break;
//					case 1:
//						LanguagePickerSource = "sq";
//						break;
//					case 2:
//						LanguagePickerSource = "ar";
//						break;
//					case 3:
//						LanguagePickerSource = "fr";
//						break;
//					case 4:
//						LanguagePickerSource = "nl";
//						break;
//					case 5:
//						LanguagePickerSource = "en";
//						break;
//					case 6:
//						LanguagePickerSource = "ru";
//						break;
//					case 7:
//						LanguagePickerSource = "de";
//						break;
//					case 8:
//						LanguagePickerSource = "tr";
//						break;
//					}

		}


		public ICommand Translate {
			get {
				return new Command (async (T) => {
					SwitchSelectLanguage ();
					LanguagePickerSource = "auto";
					TranslateService traduire = new TranslateService ();
					ContentTranslate = await traduire.TranslateAsync (ContentText, LanguagePickerSource, LanguagePickerTranslate);
				});
			}
		}
	
	}
}