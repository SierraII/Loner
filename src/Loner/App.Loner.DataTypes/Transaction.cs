using System;
using System.Globalization;

namespace App.Loner.DataTypes
{
	public class Transaction
	{

		public long MSISDN { get; set; }
		public string Name { get; set; }
		public DateTime DateTime { get; set; }
		public string Product { get; set; }
		public decimal Amount { get; set; }
		public string Data { get; set; }

		public Transaction(long msisdn, string name, string date, string product, decimal amount, string data)
		{
			this.MSISDN = msisdn;
			this.Name = clean(name);
			this.DateTime = DateTime.ParseExact(clean(date), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
			this.Product = clean(product);
			this.Amount = amount;
			this.Data = data;
		}

		public string clean(string input)
		{
			return input.Trim().Replace("'", "");
		}

	}
}

