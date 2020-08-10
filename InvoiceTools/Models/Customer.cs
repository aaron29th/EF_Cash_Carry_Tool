namespace InvoiceTools.Models
{
	public class Customer
	{
		public string Code { get; set; }

		public string PreferredName { get; set; }
		public string QuickSelectText { get; set; }

		public string Name { get; set; }
		public string[] Address { get; set; }
		public string PostCode { get; set; }
	}
}
