namespace App.Loner.DataTypes
{
	public class Product
	{

		public decimal Amount { get; set; }
		public string Name { get; set; }

		public Product(string productName, decimal amount)
		{
			this.Name = productName;
			this.Amount = amount;
		}

	}
}
