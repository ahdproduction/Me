using System;
using Me.Droid;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency (typeof(SQLite_Android))]
namespace Me.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android ()
		{
		}

		public SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "ME.db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine (documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection (path);
			// Return the database connection
			return conn;
		}
	}
}

