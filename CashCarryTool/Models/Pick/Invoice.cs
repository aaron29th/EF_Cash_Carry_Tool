using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.Models.Pick
{
	class Invoice
	{
		public int InvoiceNumber { get; set; }

		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }

		public DateTime DeliveryBy { get; set; }
		public DateTime Date { get; set; }

		public int Route { get; set; }
		public int Drop { get; set; }

		public string Address { get; set; }
		public string PostCode { get; set; }

		public Section Ambient { get; set; }
		public Section Frozen { get; set; }
		public Section Bulk { get; set; }

		public Invoice()
		{

		}

		public void ProcessPageText(string text)
		{
			ParsePdfText(text);
		}

		private void ParsePdfText(string text)
		{
			string customerCode = ExtractCustomerCode(text);
			// Check customer code is consistent
			if (!String.IsNullOrEmpty(CustomerCode) && CustomerCode != customerCode)
				return;
			CustomerCode = customerCode;

			
		}

		private static string ExtractCustomerCode(string text)
		{
			// Match customer code
			Regex customerCodeRegex = new Regex(@"(A\/C )([A-Z0-9]+)");
			var customerCodeMatch = customerCodeRegex.Match(text);
			if (customerCodeMatch.Groups.Count < 3)
				return null;
			return customerCodeMatch.Groups[2].Value;
		}

		private static string ExtractCustomerName(string text)
		{
			string[] lines = text.Split(
				new[] { Environment.NewLine },
				StringSplitOptions.None
			);

			return null;
		}

		private static int ExtractPageNumber(string text)
		{
			// Match customer code
			Regex pageNumberRegex = new Regex(@"(Page: )([0-9]+)");
			var pageNumberMatch = pageNumberRegex.Match(text);
			if (pageNumberMatch.Groups.Count < 3)
				return -1;
			return Convert.ToInt32(pageNumberMatch.Groups[2].Value);
		}

		private static SectionType ExtractSectionType(string text)
		{
			if (text.Contains("1-Frozen"))
				return SectionType.Ambient;
			if (text.Contains("1-Frozen"))
				return SectionType.Frozen;
			if (text.Contains("djf"))
				return SectionType.Bulk;

			return SectionType.Invalid;
		}
	}
}
