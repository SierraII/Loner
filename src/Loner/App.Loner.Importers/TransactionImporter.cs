using App.Loner.DataTypes;
using System.Collections.Generic;
using App.Loner.Serializers;
using System;

namespace App.Loner.Importers
{
	public class TransactionImporter
	{

		public TransactionImporter()
		{
			
		}

		public List<Network> AggrigateTransactionsFromCSV(string fileLocation)
		{
			List<Transaction> rawTransactions = new CSVSerializer(fileLocation).readFromCSV();
			List<Network> aggrigatedTransactions = new List<Network>();

			foreach(var transaction in rawTransactions)
			{
				
				var response = aggrigatedTransactions.Find(e => e.Name == transaction.Name);

				if (response != null)
				{
					Console.WriteLine("network found... " + response.Name);
					response.addLoan(transaction.DateTime, transaction.Product, transaction.Amount);
				}

				else
				{
					Console.WriteLine("network not found... adding " + transaction.Name);

					Network network = new Network(transaction.MSISDN, transaction.Name);
					network.addLoan(transaction.DateTime, transaction.Product, transaction.Amount);

					aggrigatedTransactions.Add(network);
				}

			}

			return aggrigatedTransactions;

		}

	}
}
