using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Me
{
	public partial class TranslatePage : ContentPage
	{
		TranslateViewModel tr = new TranslateViewModel();

		Dictionary<string, string> nameToColor = new Dictionary<string, string> {
			{ "Arabe", "ar" }, { "Français", "fr"},
		};

		public TranslatePage ()
		{
			foreach (string colorName in nameToColor.Keys) {
				Mypicker.Items.Add (colorName);
			}



			Mypicker.SelectedIndexChanged += (sender, args) => {
				if (Mypicker.SelectedIndex == -1) {
					tr.Language = "fr";
				} else {
					string colorName = Mypicker.Items [Mypicker.SelectedIndex];
					tr.Language = nameToColor [colorName];
				}
			};

		}
	}
}

