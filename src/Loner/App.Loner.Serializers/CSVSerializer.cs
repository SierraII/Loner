﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using App.Loner.DataTypes;

namespace App.Loner.Serializers
{
	public class CSVSerializer
	{

		public void exportAggrigatedList(List<Network> networks, string filename)
		{

			Console.WriteLine("creating aggregated output file...");

			using (StreamWriter file = new StreamWriter(@filename))
			{
				
				file.WriteLine("Network,Product,Month,Amount");

				foreach (var network in networks)
				{
					foreach (var loan in network.loans)
					{
						foreach (var product in loan.products)
						{
							file.WriteLine(network.Name + "," + product.Name + "," + loan.DateTime.ToString("dd-MMM-yyyy") + "," + product.Amount);
						}
					}
				}

				Console.WriteLine("file successfully written.");

			}

		}

		public List<Transaction> readFromCSV(string fileLocation)
		{

			List<Transaction> transactions = new List<Transaction>();
			int count = 0;
			string line;

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
								Console.WriteLine("error parsing values to network model: " + ex.Message);
							}

						}

						count++;

					}

				}

			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine("file not found");
			}

			return transactions;

		}
	}
}
