using System;
using System.Globalization;

namespace App.Loner.DataTypes
{
	public class Transaction
	{

		public DateTime DateTime { get; set; }
		public string Product { get; set; }
		public decimal Amount { get; set; }		
		public long MSISDN { get; set; }
		public string Name { get; set; }
		public string Data { get; set; }

		public Transaction(long msisdn, string name, string date, string product, decimal amount, string data)
		{
            this.DateTime = DateTime.ParseExact(clean(date), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            this.Product = clean(product);
            this.Name = clean(name);			
			this.MSISDN = msisdn;
			this.Amount = amount;
			this.Data = data;
		}

		public string clean(string input)
		{
			return input.Trim().Replace("'", "");
		}

	}
}

