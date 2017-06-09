using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using App.Loner.DataTypes;

namespace App.Loner.Serializers
{
	public class CSVSerializer
	{

		public void exportAggrigatedList(List<Network> networks, string filename)
		{
			var text = "Network,Product,Month,Amount\n";

			foreach (var network in networks)
			{

				foreach (var loan in network.loans)
				{

					foreach (var product in loan.products)
					{
						text += network.Name + "," + product.Name + "," + loan.DateTime.ToString("dd-MMM-yyyy") + "," + product.Amount + "\n";
					}
				
				}

			}

			Console.WriteLine(text);

		}

		public List<Transaction> readFromCSV(string fileLocation)
		{
			List<Transaction> transactions = new List<Transaction>();

			string line;
			int count = 0;

			using (var file = new StreamReader(fileLocation))
			{
				while ((line = file.ReadLine()) != null)
				{
					// skip first line
					if(count > 0)
					{
						
						string[] words = line.Split(',');
						try
						{
							Transaction transaction = new Transaction(long.Parse(words[0]), words[1], words[2], words[3], decimal.Parse(words[4], CultureInfo.InvariantCulture), line);
							transactions.Add(transaction);
						}
						catch(Exception ex)
						{
							Console.WriteLine("error parsing network values " + ex.StackTrace + " " + ex.Message);
						}

					}

					count++;

				}

			}

			return transactions;
		}
	}
}
