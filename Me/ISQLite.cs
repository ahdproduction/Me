using System;
using SQLite;

namespace Me
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}