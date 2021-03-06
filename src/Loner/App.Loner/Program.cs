﻿using System;
using App.Loner.DataTypes;
using App.Loner.Importers;
using App.Loner.Serializers;
using System.Collections.Generic;
using System.Threading;

namespace App.Loner
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			TransactionImporter transactionImporter = new TransactionImporter();
			List<Network> aggregatedNetworkList = transactionImporter.aggrigateTransactionsFromCSV("../../../../loans.csv");

			if (aggregatedNetworkList.Count > 0)
			{
				CSVSerializer csvSerializer = new CSVSerializer();
				csvSerializer.exportAggrigatedList(aggregatedNetworkList, "../../../../output.csv");
			}
			else
			{
				Core.Context.log.i("no aggrigated transactions, file not being written.");
			}

			Console.ReadLine();

			while (true)
			{
				Thread.Sleep(1000);
			}

		}
	}
}
