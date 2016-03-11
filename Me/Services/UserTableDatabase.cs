using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Me
{
	public class UserTableDatabase
	{
		SQLiteConnection database;

		public UserTableDatabase ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<User> ();
		}


		public int SaveItemToDB (User User)
		{
			return database.Insert (User);
		}

		public int DeleteItemFromDB (User User)
		{
			return database.Delete (User);
		}

		public IEnumerable<User> GetItems ()
		{
			return (from i in database.Table<User> ()
				select i)?.ToList();
		}

		public User GetItem (string email, string password)
		{
			return database.Table<User> ().FirstOrDefault (a => a.Email == email && a.Password == password);
		}

		public IEnumerable<User>  SearchItems (string search)
		{
			return database.Table<User> ().Where (x => x.Name == search ||
				x.FirstName == search||
				x.NickName == search ||
				x.Email == search).ToList();
		}


	}
}

