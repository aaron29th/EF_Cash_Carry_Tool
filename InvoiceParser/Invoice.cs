using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.Models.Pick;

namespace InvoiceParser
{
	public class Invoice
	{
		public int InvoiceNumber { get; set; }

		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }

		public DateTime DeliveryBy { get; set; }
		public DateTime Date { get; set; }

		public int Route { get; set; }
		public int Drop { get; set; }
		public string Reference { get; set; }

		public string[] Address { get; set; }
		public string PostCode { get; set; }

		public int AmbientUnits { get; set; }
		public int BulkAmbientUnits { get; set; }
		public int BulkFrozenUnits { get; set; }
		public int FrozenUnits { get; set; }

		public List<InvoicePage> Pages { get; set; }

		public Invoice()
		{
			Address = new string[4];
			Pages = new List<InvoicePage>();
		}

		public Invoice(InvoicePage page)
		{
			Pages = new List<InvoicePage>();

			InvoiceNumber = page.InvoiceNumber;

			CustomerCode = page.CustomerCode;
			CustomerName = page.CustomerName;

			DeliveryBy = page.DeliveryBy;
			Date = page.Date;

			Route = page.Route;
			Drop = page.Drop;
			Reference = page.Reference;

			Address = page.Address;
			PostCode = page.PostCode;
		}

		public void AddPage(InvoicePage page)
		{
			if (page.InvoiceNumber != InvoiceNumber)
				throw new InvoiceException($"Inconsistent Invoice numbers, invoice: {page.InvoiceNumber} page: {page.PageNumber} attempted to be added to invoice: ${InvoiceNumber}");

			if (page.DeliveryBy.Equals(page.DeliveryBy))
				throw new InvoiceException($"Inconsistent delivery dates, invoice: {page.InvoiceNumber} page: {page.PageNumber} deliver by: {page.DeliveryBy.ToShortDateString()} " + $"" +
				                           $"attempted to be added to invoice: ${InvoiceNumber} deliver by ${DeliveryBy.ToShortDateString()}");

			if (Pages.Contains(page))
				throw new InvoiceException($"Duplicate page, invoice: {page.InvoiceNumber} page: {page.PageNumber}");

			if (Pages.Count(x => x.Section == page.Section && x.PageNumber == page.PageNumber) > 0)
				throw new InvoiceException($"Duplicate page, invoice: {page.InvoiceNumber} page: {page.PageNumber}");

			Pages.Add(page);
		}
	}
}
