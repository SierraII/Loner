using System;
using App.Loner.Utils;
using App.Loner.Importers;

namespace App.Loner
{
	public class Core
	{
		public static Logcat Log { get; set; }
		public static NetworkImporter NetworkImporter { get; set; }

		public static void Boot()
		{
			Console.WriteLine("Loner is running...");

			Log = new Logcat();
			NetworkImporter = new NetworkImporter("Loans.csv");
		}

	}
}
