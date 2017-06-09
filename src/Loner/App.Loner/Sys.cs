using App.Loner.Utils;
using App.Loner.Importers;
using System.Collections.Generic;
using App.Loner.DataTypes;
using App.Loner.Serializers;

namespace App.Loner
{
	public static class Sys
	{
		public static TransactionImporter NetworkImporter { get; set; }
		public static CSVSerializer CSVSerializer { get; set; }

		static Sys()
		{
			NetworkImporter = new TransactionImporter();
			CSVSerializer = new CSVSerializer();
		}

		public static void Boot()
		{
			List<Network> aggregatedNetworkList = NetworkImporter.AggrigateTransactionsFromCSV("../../../../loans.csv");
			CSVSerializer.exportAggrigatedList(aggregatedNetworkList, "output.csv");
		}
	}
}
