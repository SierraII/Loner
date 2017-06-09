using System;
using System.Collections.Generic;

namespace App.Loner.DataTypes
{
	public class Network
	{

		public long MSISDN { get; set; }
		public string Name { get; set; }
		public List<Loan> loans { get; set; }

		public Network(long msisdn, string name)
		{
			this.MSISDN = msisdn;
			this.Name = name;
			this.loans = new List<Loan>();
		}

		public void addLoan(DateTime date, string productName, decimal amount)
		{
			
			// check if the month already exists
			var loanExists = this.loans.Find(e => e.DateTime.Month == date.Month);

			if (loanExists != null)
			{
				var productExists = loanExists.products.Find(e => e.Name == productName);

				if (productExists != null)
				{
					Console.WriteLine("the product exists already...");
					productExists.Amount += amount;
				}
				else
				{
					Console.WriteLine("the product doesn't exist...");

					Product product = new Product();
					product.Name = productName;
					product.Amount = amount;
					loanExists.products.Add(product);
				}
			}
			else
			{
				Loan loan = new Loan();
				loan.DateTime = date;

				Product product = new Product();
				product.Name = productName;
				product.Amount = amount;

				loan.products = new List<Product>();
				loan.products.Add(product);

				this.loans.Add(loan);
			}

		}


	}

	public class Loan
	{
		public DateTime DateTime { get; set; }
		public List<Product> products { get; set; }
	}

	public class Product
	{
		public decimal Amount { get; set; }
		public string Name { get; set; }
	}

}
