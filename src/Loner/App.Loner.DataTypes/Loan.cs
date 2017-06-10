using System;
using System.Collections.Generic;

namespace App.Loner.DataTypes
{
	public class Loan
	{
		public DateTime DateTime { get; set; }
		public List<Product> products { get; set; }

		public Loan(DateTime date)
		{
			this.DateTime = date;
            this.products = new List<Product>();
		}

	}
}
