namespace ElectronicStoreServer.Data
{
	public abstract class Item
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public double Price { get; set; }
		public int Amount { get; set; }

		public override string ToString()
		{
			return $"Name: {Brand}, Price: {Price:C}";
		}
	}
}
