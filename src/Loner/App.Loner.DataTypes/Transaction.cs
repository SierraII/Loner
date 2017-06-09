using System;
using System.Globalization;

namespace App.Loner.DataTypes
{
	public class Transaction
	{

		public long MSISDN { get; set; }
		public string Name { get; set; }
		public string Data { get; set; }
		public string Product { get; set; }
		public decimal Amount { get; set; }
		public DateTime DateTime { get; set; }

		public Transaction(long msisdn, string name, string date, string product, decimal amount, string data)
		{
			this.Data = data;
			this.Amount = amount;
			this.MSISDN = msisdn;
			this.Name = clean(name);
			this.Product = clean(product);
			this.DateTime = DateTime.ParseExact(clean(date), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
		}

		public string clean(string input)
		{
			return input.Trim().Replace("'", "");
		}

	}
}

