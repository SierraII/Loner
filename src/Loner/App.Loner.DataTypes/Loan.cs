using System;
using System.Collections.Generic;

namespace App.Loner.DataTypes
{
	public class Loan
	{
		
		public List<Product> products { get; set; }
		public DateTime DateTime { get; set; }

		public Loan(DateTime date)
		{
            this.products = new List<Product>();
			this.DateTime = date;
		}

	}
}
