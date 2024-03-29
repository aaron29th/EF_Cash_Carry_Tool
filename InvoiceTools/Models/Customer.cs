﻿namespace InvoiceTools.Models
{
	public class Customer
	{
		public string Code { get; set; }

		public string PreferredName { get; set; }
		public string QuickSelectText { get; set; }

		public string Name { get; set; }

		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string AddressLine3 { get; set; }
		public string AddressLine4 { get; set; }

		public string PostCode { get; set; }
	}
}
