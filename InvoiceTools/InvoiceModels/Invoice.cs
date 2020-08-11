using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace InvoiceTools.InvoiceModels
{
	public class Invoice
	{
		public int InvoiceNumber { get; set; } = -1;

		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }

		public DateTime DeliveryBy { get; set; }
		public DateTime Date { get; set; }

		public int Route { get; set; }
		public int Drop { get; set; }
		public string Reference { get; set; }

		public string[] Address { get; set; }
		public string PostCode { get; set; }

		// Duplicated so can be overriden by user
		public int AmbientUnits { get; set; }
		public int BulkAmbientUnits { get; set; }
		public int BulkFrozenUnits { get; set; }
		public int FrozenUnits { get; set; }

		public List<PickLine> Frozen { get; set; }
		public List<PickLine> BulkFrozen { get; set; }

		public List<PickLine> Ambient { get; set; }
		public List<PickLine> BulkAmbient { get; set; }

		public Invoice()
		{
			Address = new string[4];

			Frozen = new List<PickLine>();
			BulkFrozen = new List<PickLine>();

			Ambient = new List<PickLine>();
			BulkAmbient = new List<PickLine>();
		}

		public Invoice(InvoicePage page) : this()
		{
			InitProperties(page);
			AddPage(page);
		}

		private void InitProperties(InvoicePage page)
		{
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

		private void CheckDuplicate(List<PickLine> lines, InvoicePage page)
		{
			if (lines.Count(x => x.PageNumber == page.PageNumber) > 0)
				throw new InvoiceException($"Duplicate page, invoice: {page.InvoiceNumber} page: {page.PageNumber}");
		}

		public void AddPage(InvoicePage page)
		{
			if (InvoiceNumber == -1)
				InitProperties(page);

			if (page.InvoiceNumber != InvoiceNumber)
				throw new InvoiceException($"Inconsistent Invoice numbers, invoice: {page.InvoiceNumber} page: {page.PageNumber} attempted to be added to invoice: ${InvoiceNumber}");

			if (!page.DeliveryBy.Equals(DeliveryBy))
				throw new InvoiceException($"Inconsistent delivery dates, invoice: {page.InvoiceNumber} page: {page.PageNumber} deliver by: {page.DeliveryBy.ToShortDateString()} " +
				                           $"attempted to be added to invoice: {InvoiceNumber} deliver by {DeliveryBy.ToShortDateString()}");
			
			switch (page.Section)
			{
				case SectionType.Frozen:
					CheckDuplicate(Frozen, page);
					Frozen.AddRange(page.Lines);
					break;
				case SectionType.Bulk:
					CheckDuplicate(BulkFrozen, page);
					BulkFrozen.AddRange(page.Lines);
					break;
				case SectionType.Ambient:
					CheckDuplicate(Ambient, page);
					Ambient.AddRange(page.Lines);
					break;
				case SectionType.AmbientBulk:
					CheckDuplicate(BulkAmbient, page);
					BulkAmbient.AddRange(page.Lines);
					break;
			}
		}
	}
}
