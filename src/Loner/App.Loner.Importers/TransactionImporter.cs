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

		public List<Transaction> AggrigateTransactionsFromCSV(string fileLocation)
		{
			List<Transaction> rawTransactions = new CSVSerializer(fileLocation).readFromCSV();

			foreach(var transaction in rawTransactions)
			{
				Console.WriteLine(transaction.MSISDN);
			}

			List<Transaction> aggrigatedTransactions = new List<Transaction>();

			return aggrigatedTransactions;

		}

	}
}
