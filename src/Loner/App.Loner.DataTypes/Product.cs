namespace App.Loner.DataTypes
{
	public class Product
	{

		public decimal Amount { get; set; }
		public string Name { get; set; }
		public int Count { get; set; }

		public Product(string productName, decimal amount)
		{
            this.Count = 1;
			this.Name = productName;
			this.Amount = amount;
		}

	}
}
