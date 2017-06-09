using App.Loner.DataTypes;
using System.Collections.Generic;
using App.Loner.Serializers;
namespace App.Loner.Importers
{
	public class TransactionImporter
	{

		public TransactionImporter()
		{
			
		}

		public List<Transaction> AggrigateTransactionsFromCSV(string fileLocation)
		{
			List<Transaction> transactions = new CSVSerializer(fileLocation).readFromCSV();

			return transactions
		}

	}
}
