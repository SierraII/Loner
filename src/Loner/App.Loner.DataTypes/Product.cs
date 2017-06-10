namespace App.Loner.DataTypes
{
	public class Product
	{

		public int Count { get; set; }
		public string Name { get; set; }
		public decimal Amount { get; set; }

		public Product(string productName, decimal amount)
		{
			this.Count = 1;
			this.Amount = amount;
			this.Name = productName;
		}

	}
}
