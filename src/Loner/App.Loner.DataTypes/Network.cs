using System;
using System.Collections.Generic;

namespace App.Loner.DataTypes
{
	public class Network
	{

		public List<Loan> loans { get; set; }
		public long MSISDN { get; set; }
		public string Name { get; set; }

		public Network(long msisdn, string name)
		{
            this.loans = new List<Loan>();
			this.MSISDN = msisdn;
			this.Name = name;
		}

		public void addLoan(DateTime date, string productName, decimal amount)
		{
			// check if the month and year already exists in that object
			var existingLoan = this.loans.Find(e => e.DateTime.Month == date.Month && e.DateTime.Year == date.Year);

			if (existingLoan == null)
			{
				// create the loan and products
				Core.Context.log.i(this.Name + " - " + productName + " doesn't exist in " + date.ToString("MMMM") + "... adding.");

				Product product = new Product(productName, amount);

				Loan loan = new Loan(date);
				loan.products.Add(product);

				this.loans.Add(loan);
			}
			else
			{
				// check for existing products in the loan (within the scope of that month)
				var existingProduct = existingLoan.products.Find(e => e.Name == productName);

				if (existingProduct == null)
				{
					// create the product
					Core.Context.log.i(this.Name + " - " + productName + " doesn't exist in month " + date.ToString("MMMM") + "... adding.");
					Product product = new Product(productName, amount);
					existingLoan.products.Add(product);
				}
				else
				{
					// ammend the amount
					Core.Context.log.i(this.Name + " - " + productName + " exists in month " + date.ToString("MMMM") + ", incrementing amount by " + amount + ".");
					existingProduct.Amount += amount;
					existingProduct.Count += 1;
				}

			}

		}

	}
}
