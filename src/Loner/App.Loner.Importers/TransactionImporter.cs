using App.Loner.DataTypes;
using App.Loner.Serializers;
using System.Collections.Generic;

namespace App.Loner.Importers
{
	public class TransactionImporter
	{

		public List<Network> aggrigateTransactionsFromCSV(string fileLocation)
		{
			// keeping the raw transactions for future-proofing
			List<Transaction> rawTransactions = new CSVSerializer().readFromCSV(fileLocation);
			List<Network> aggrigatedTransactions = new List<Network>();

			Core.Context.log.i("found " + rawTransactions.Count + " transactions.");

			foreach (var transaction in rawTransactions)
			{

				// check if the transaction name exists
				var existingTransaction = aggrigatedTransactions.Find(e => e.Name == transaction.Name);

				if (existingTransaction == null)
				{
					Network network = new Network(transaction.MSISDN, transaction.Name);
					network.addLoan(transaction.DateTime, transaction.Product, transaction.Amount);

					aggrigatedTransactions.Add(network);
				}
				else
				{
					existingTransaction.addLoan(transaction.DateTime, transaction.Product, transaction.Amount);
				}

			}

			return aggrigatedTransactions;

		}

	}
}
