using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceTools.InvoiceModels;

namespace InvoiceTools
{
	public static class InvoiceHelper
	{
		private static List<int> GetInvoiceFrozenQuanities(List<Invoice> invoices)
		{
			var allFrozenLines = invoices.Select(x => x.Frozen);
			var quantityNums = new List<int>();
			foreach (var frozenLists in allFrozenLines)
			{
				quantityNums.AddRange(frozenLists.Select(x => x.Ordered));
			}

			return quantityNums;
		}

		public static double GetMeanFrozen(List<Invoice> invoices)
		{
			if (invoices.Count == 0)
				return 0;

			var quantities = GetInvoiceFrozenQuanities(invoices);
			if (quantities.Count == 0)
				return 0;

			return quantities.Average();
		}

		public static int GetModeFrozen(List<Invoice> invoices)
		{
			if (invoices.Count == 0)
				return 0;
			
			var quantities = GetInvoiceFrozenQuanities(invoices);
			if (quantities.Count == 0)
				return 0;

			return quantities.GroupBy(n => n).
				OrderByDescending(g => g.Count()).
				Select(g => g.Key).FirstOrDefault();
		}

		public static int GetMedianFrozen(List<Invoice> invoices)
		{
			if (invoices.Count == 0)
				return 0;
			
			var quantities = GetInvoiceFrozenQuanities(invoices);
			if (quantities.Count == 0)
				return 0;

			int halfIndex = quantities.Count / 2;
			var sortedNumbers = quantities.OrderBy(n => n);

			// If perfect middle return
			if ((quantities.Count % 2) != 0)
				return sortedNumbers.ElementAt(halfIndex);

			// Else average middle two
			int middleFirst = sortedNumbers.ElementAt(halfIndex - 1);
			int middleSecond = sortedNumbers.ElementAt(halfIndex);
			return (middleFirst + middleSecond) / 2;
		}
	}
}
