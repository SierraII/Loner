using App.Loner.Importers;
using App.Loner.Serializers;
using System.Collections.Generic;
using App.Loner.DataTypes;

namespace App.Loner
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			TransactionImporter transactionImporter = new TransactionImporter();
			CSVSerializer csvSerializer = new CSVSerializer();

			List<Network> aggregatedNetworkList = transactionImporter.aggrigateTransactionsFromCSV("../../../../loans.csv");
			csvSerializer.exportAggrigatedList(aggregatedNetworkList, "output.csv");
		}
	}
}
