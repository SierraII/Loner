using System;

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
			this.Name = name;
			this.DateTime = new DateTime();
			this.Product = product;
			this.Amount = amount;
			this.Data = data;
		}

	}
}
