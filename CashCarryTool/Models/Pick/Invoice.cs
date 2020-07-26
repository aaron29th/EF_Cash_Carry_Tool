using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet;
using PdfiumViewer;

namespace Eden_Farm_Cash___Carry_Tool.Models.Pick
{
	class Invoice
	{
		private string[] _pagesText;

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

		public Section Frozen { get; set; }
		public Section Bulk { get; set; }
		public Section Ambient { get; set; }
		public Section AmbientBulk { get; set; }

		public Invoice()
		{
			Address = new string[4];

			Frozen = new Section();
			Bulk = new Section();
			Ambient = new Section();
			AmbientBulk = new Section();
		}

		public void ProcessInvoice(string[] pagesText, string customerName)
		{
			_pagesText = pagesText;
			CustomerName = customerName;

			for (int pageIndex = 0; pageIndex < _pagesText.Length; pageIndex++)
			{
				ProcessPage(pageIndex);
			}
		}

		private void ProcessPage(int pageIndex)
		{
			if (_pagesText == null || _pagesText.Length <= pageIndex)
				return;


			int pageNumber = ExtractPageNumber(pageIndex);
			var sectionType = ExtractSectionType(pageIndex);

			switch (sectionType)
			{
				case SectionType.Frozen:
					break;
				case SectionType.Bulk:
					break;
				case SectionType.Ambient:
					break;
				case SectionType.AmbientBulk:
					break;
				default:
					throw new InvoiceException("Section type not recognized");
			}

			// Extract and check on every page
			ExtractCheckCustomerCode(pageIndex);
			ExtractInvoiceNumber(pageIndex);
			ExtractDeliveryDate(pageIndex);

			// Only extract on first page
			if (pageIndex != 0)
				return;
			ExtractPostCode(pageIndex);
			ExtractCustomerNameAndAddress(pageIndex);
			ExtractRouteAndDrop(pageIndex);
			ExtractReference(pageIndex);
			ExtractInvoiceDate(pageIndex);
		}

		private void ExtractCheckCustomerCode(int pageIndex)
		{
			var pageText = _pagesText[pageIndex];

			// Match customer code
			Regex customerCodeRegex = new Regex(@"(A\/C )([A-Z0-9]+)");
			var customerCodeMatch = customerCodeRegex.Match(pageText);
			if (customerCodeMatch.Groups.Count < 3)
				throw new InvoiceException("Customer code could not be found");

			string customerCode = customerCodeMatch.Groups[2].Value;
			// Check customer code is consistent
			if (!String.IsNullOrEmpty(CustomerCode) && CustomerCode != customerCode)
				throw new InvoiceException("Customer code inconsistent");
			CustomerCode = customerCode;
		}

		private void ExtractPostCode(int pageIndex)
		{
			string[] lines = GetPageLines(pageIndex);

			var postCodeLine = lines[5];

			// Match customer code
			Regex postCodeRegex = new Regex(@"(([A-Z]{1,2}[0-9][A-Z0-9]?|ASCN|STHL|TDCU|BBND|[BFS]IQQ|PCRN|TKCA) ?[0-9][A-Z]{2}|BFPO ?[0-9]{1,4}|(KY[0-9]|MSR|VG|AI)[ -]?[0-9]{4}|[A-Z]{2} ?[0-9]{2}|GE ?CX|GIR ?0A{2}|SAN ?TA1)$");
			var postCodeMatch = postCodeRegex.Match(postCodeLine);
			if (postCodeMatch.Groups.Count < 1)
			{
				PostCode = "";
				return;
			}

			PostCode = postCodeMatch.Groups[0].Value;
		}

		private void ExtractCustomerNameAndAddress(int pageIndex)
		{
			string[] lines = GetPageLines(pageIndex);

			// Address line 1
			if (CustomerCode != null)
			{
				string addressLine1 = lines[2];
				int addressLine1Start = addressLine1.IndexOf(CustomerCode, StringComparison.Ordinal);
				addressLine1 = addressLine1.Substring(addressLine1Start + CustomerCode.Length);
				Address[0] = addressLine1.Trim();
			}
			else
			{
				Address[0] = "";
			}

			// Address line 3
			string addressLine3 = lines[4].Trim();
			Address[2] = addressLine3;

			// Address line 4
			string addressLine4 = lines[5];
			if (PostCode != null)
				addressLine4 = addressLine4.Replace(PostCode, "");

			Address[3] = addressLine4.Trim();

			// Customer name and address line 2
			var nameLine = lines[3]
				.Replace("1-Frozen", "")
				.Replace("?-Bulk", "")
				.Replace("?-Ambient", "")
				.Replace("6-Bulk Ambient", "")
				.Trim();

			// Avoid dialog if possible
			if (CustomerName != null)
			{
				if (!nameLine.Contains(CustomerName))
					throw new InvoiceException("Customer name inconsistent");

				Address[1] = nameLine.Replace(CustomerName, "").Trim();
				return;
			}

			using (var form = new SplitCustomerNameAddressForm(nameLine))
			{
				form.ShowDialog();

				CustomerName = form.CustomerName;
				Address[1] = form.CustomerAddressLine;
			}
		}

		private void ExtractInvoiceNumber(int pageIndex)
		{
			var pageText = _pagesText[pageIndex];

			// Match invoice number
			Regex invoiceNumberRegex = new Regex(@"(Order:)([0-9]+)");
			var invoiceNumberMatch = invoiceNumberRegex.Match(pageText);
			if (invoiceNumberMatch.Groups.Count < 3)
				throw new InvoiceException();
			
			// If possible remove trailing 00's
			var invoiceNumber = Convert.ToInt32(invoiceNumberMatch.Groups[2].Value);
			if (invoiceNumber % 100 == 0 && invoiceNumber >= 10000000)
				invoiceNumber /= 100;

			// Check invoice number consistent
			if (InvoiceNumber != 0 && InvoiceNumber != invoiceNumber)
				throw new InvoiceException("Invoice number inconsistent");
			InvoiceNumber = invoiceNumber;
		}

		private void ExtractDeliveryDate(int pageIndex)
		{
			var pageText = _pagesText[pageIndex];

			// Match delivery date
			Regex deliveryDateRegex = new Regex(@"(Deliver by:)([0-9]{2})(\/)([0-9]{2})(\/)([0-9]{2})");
			var deliveryDateMatch = deliveryDateRegex.Match(pageText);
			if (deliveryDateMatch.Groups.Count < 7)
				throw new InvoiceException("Delivery date could not be found");

			int dayNumber = Convert.ToInt32(deliveryDateMatch.Groups[2].Value);
			int monthNumber = Convert.ToInt32(deliveryDateMatch.Groups[4].Value);
			int yearNumber = Convert.ToInt32("20" + deliveryDateMatch.Groups[6].Value);

			DeliveryBy = new DateTime(yearNumber, monthNumber, dayNumber);
		}

		private void ExtractInvoiceDate(int pageIndex)
		{
			var pageText = _pagesText[pageIndex];

			// Match delivery date
			Regex invoiceDateRegex = new Regex(@"(Date :)([0-9]{2})(\/)([0-9]{2})(\/)([0-9]{2})");
			var invoiceDateMatch = invoiceDateRegex.Match(pageText);
			if (invoiceDateMatch.Groups.Count < 7)
				throw new InvoiceException("Invoice date could not be found");

			int dayNumber = Convert.ToInt32(invoiceDateMatch.Groups[2].Value);
			int monthNumber = Convert.ToInt32(invoiceDateMatch.Groups[4].Value);
			int yearNumber = Convert.ToInt32("20" + invoiceDateMatch.Groups[6].Value);

			Date = new DateTime(yearNumber, monthNumber, dayNumber);
		}

		private void ExtractRouteAndDrop(int pageIndex)
		{
			var pageText = _pagesText[pageIndex];

			// Match route number
			Regex routeDropRegex = new Regex(@"(Route : )([0-9]+)( \/ )([0-9]+)");
			var routeDropMatch = routeDropRegex.Match(pageText);
			if (routeDropMatch.Groups.Count < 5)
				throw new InvoiceException("Route and drop numbers could not be found");

			Route = Convert.ToInt32(routeDropMatch.Groups[2].Value);
			Drop = Convert.ToInt32(routeDropMatch.Groups[4].Value);
		}

		private void ExtractReference(int pageIndex)
		{
			var pageText = _pagesText[pageIndex];

			// Match reference
			Regex referenceRegex = new Regex(@"(Ref:)([a-zA-Z0-9 ]+)");
			var referenceMatch = referenceRegex.Match(pageText);

			if (referenceMatch.Groups.Count < 3)
			{
				Reference = "";
				return;
			}

			Reference = referenceMatch.Groups[2].Value;
		}

		private int ExtractPageNumber(int pageIndex)
		{
			var pageText = _pagesText[pageIndex];

			// Match page number
			Regex pageNumberRegex = new Regex(@"(Page: )([0-9]+)");
			var pageNumberMatch = pageNumberRegex.Match(pageText);
			if (pageNumberMatch.Groups.Count < 3)
				return -1;
			return Convert.ToInt32(pageNumberMatch.Groups[2].Value);
		}

		private SectionType ExtractSectionType(int pageIndex)
		{
			var pageText = _pagesText[pageIndex];

			if (pageText.Contains("1-Frozen"))
				return SectionType.Frozen;
			if (pageText.Contains("?-Bulk"))
				return SectionType.Bulk;
			if (pageText.Contains("?-Ambient"))
				return SectionType.Ambient;
			if (pageText.Contains("6-Bulk Ambient"))
				return SectionType.AmbientBulk;

			return SectionType.Invalid;
		}

		private string[] GetPageLines(int pageIndex)
		{
			return _pagesText[pageIndex].Split(
				new[] { Environment.NewLine },
				StringSplitOptions.None
			);
		}
	}
}
