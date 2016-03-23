using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Me
{
	public class TranslateService
	{
		public TranslateService ()
		{
		}

		public async Task<string> TranslateAsync (string ContentText, string SourceLanguage, string SelectLanguage)
		{
			string ContentTranslate;

			string uri = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=" + SourceLanguage + "&tl=" + SelectLanguage + "&dt=t&q=" + ContentText;
			//string uri2 = "https://www.googleapis.com/language/translate/v2?q=bateau&target=en&format=text&fields=translations";

			var client = new HttpClient ();
			HttpResponseMessage response = await client.GetAsync (uri);

			if (response.IsSuccessStatusCode) {
				using (var ms = new MemoryStream ()) {
					await response.Content.CopyToAsync (ms);
					ms.Position = 0;

					var fileTranslate = new StreamReader (ms);
					var fileReadConvert = fileTranslate.ReadToEnd ();
					string[] substrings = fileReadConvert.Split ('"');
					foreach (string match in substrings) {
						Debug.WriteLine ("'{0}'", match);
					}
					ContentTranslate = substrings [1];
					return ContentTranslate;

				}

			}
			return "false";
		}

	}
}

