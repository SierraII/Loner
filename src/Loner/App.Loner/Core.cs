using System;
using App.Loner.Utils;
using App.Loner.Importers;
using System.Collections.Generic;
using App.Loner.DataTypes;

namespace App.Loner
{
	public class Core
	{
		public static Logcat Log { get; set; }
		public static TransactionImporter NetworkImporter { get; set; }

		public static void Boot()
		{
			Console.WriteLine("Loner is running...");

			Log = new Logcat();
			NetworkImporter = new TransactionImporter();

			List<Transaction> transactions = NetworkImporter.AggrigateNetworkFromCSV("../../../../loans.csv");
		}

	}
}
