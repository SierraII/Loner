using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using App.Loner.DataTypes;

namespace App.Loner.Serializers
{
	public class CSVSerializer
	{
		public string FileLocation { get; set; }

		public CSVSerializer(string fileLocation)
		{
			this.FileLocation = fileLocation;
		}

		public List<Transaction> readFromCSV()
		{
			List<Transaction> transactions = new List<Transaction>();

			string line;
			int count = 0;

			using (var file = new StreamReader(this.FileLocation))
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
							throw new ApplicationException("error parsing network values " + ex.StackTrace + " " + ex.Message);
						}

					}

					count++;

				}

			}

			return transactions;
		}
	}
}
