using System;
using Me.iOS;
using System.IO;

[assembly: Xamarin.Forms.Dependency (typeof(SQLite_iOS))]
namespace Me.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS ()
		{
		}

		public SQLite.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "ME.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine (libraryPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection (path);
			// Return the database connection
			return conn;
		}
	}
}

