using System.Collections.Generic;
using App.Loner.DataTypes;
using App.Loner.Serializers;

namespace App.Loner.Importers
{
	public class TransactionImporter
	{

		public List<Network> aggrigateTransactionsFromCSV(string fileLocation)
		{
			List<Transaction> rawTransactions = new CSVSerializer().readFromCSV(fileLocation);

			List<Network> aggrigatedTransactions = new List<Network>();

			foreach(var transaction in rawTransactions)
			{
				
				var response = aggrigatedTransactions.Find(e => e.Name == transaction.Name);

				if (response == null)
				{
					Network network = new Network(transaction.MSISDN, transaction.Name);
					network.addLoan(transaction.DateTime, transaction.Product, transaction.Amount);

					aggrigatedTransactions.Add(network);
				}

				else
				{
					response.addLoan(transaction.DateTime, transaction.Product, transaction.Amount);
				}

			}

			return aggrigatedTransactions;

		}

	}
}
