using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceTools.InvoiceModels;
using PdfiumViewer;

namespace InvoiceTools
{
	public static class InvoiceParser
	{
		public static List<InvoicePage> PdfDocToInvoicePages(IPdfDocument doc)
		{
			var pages = new List<InvoicePage>();

			for (int pageIndex = 0; pageIndex < doc.PageCount; pageIndex++)
			{
				var page = new InvoicePage(doc.GetPdfText(pageIndex));

				if (page.CustomerCode == null)
					continue;

				pages.Add(page);
			}

			return pages;
		}

		public static List<Invoice> InvoicePagesToInvoices(List<InvoicePage> invoicePages)
		{
			var invoices = new List<Invoice>();

			foreach (var page in invoicePages)
			{
				var invoice = invoices.FirstOrDefault(x => x.InvoiceNumber == page.InvoiceNumber);

				if (invoice == null)
				{

				}

				invoice.AddPage(page);
			}

			return invoices;
		}

		public static List<Invoice> PdfDocToInvoices(IPdfDocument doc)
		{
			var invoicePages = PdfDocToInvoicePages(doc);
			return InvoicePagesToInvoices(invoicePages);
		}
	}
}
