using System;
using System.IO;
using App.Loner.DataTypes;
using System.Globalization;
using System.Collections.Generic;

namespace App.Loner.Serializers
{
	public class CSVSerializer
	{

		public void exportAggrigatedList(List<Network> networks, string filename)
		{

			Core.Context.log.i("creating aggregated output file...");

			using (StreamWriter file = new StreamWriter(@filename))
			{

				file.WriteLine("Network,Product,Month,Count,Amount");

				foreach (var network in networks)
				{
					foreach (var loan in network.loans)
					{
						foreach (var product in loan.products)
						{

							file.WriteLine(network.Name +
										   "," + product.Name +
										   "," + loan.DateTime.ToString("MMM-yyyy") +
										   "," + product.Count +
										   "," + product.Amount.ToString().Replace(",", "."));

						}
					}
				}

				Core.Context.log.i("file successfully written.");

			}

		}

		public void writeFailedDataToCSV(string line)
		{
			using (StreamWriter file = new StreamWriter("../../../../failed_transactions.csv", true))
			{
				file.WriteLine(DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss ffff") + "," + line);
			}

			Core.Context.log.i("appending failed transaction to file...");
		}

		public List<Transaction> readFromCSV(string fileLocation)
		{
			
			Core.Context.log.i("loading transactions...");

			string line;
			int count = 0;
			List<Transaction> transactions = new List<Transaction>();

			try
			{

				using (var file = new StreamReader(@fileLocation))
				{

					while ((line = file.ReadLine()) != null)
					{
						// skip first line
						if (count > 0)
						{

							string[] words = line.Split(',');
							try
							{
								Transaction transaction = new Transaction(long.Parse(words[0]), words[1], words[2], words[3], decimal.Parse(words[4], CultureInfo.InvariantCulture), line);
								transactions.Add(transaction);
							}
							catch (Exception ex)
							{
								Core.Context.log.e("error parsing values to transaction model: " + ex.Message);
								writeFailedDataToCSV(line);
							}

						}

						count++;

					}

				}

				Core.Context.log.i("transactions loaded.");

			}
			catch (FileNotFoundException ex)
			{
				Core.Context.log.e("file not found...");
			}

			return transactions;

		}

	}
}
