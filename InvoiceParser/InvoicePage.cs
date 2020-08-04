using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.Models.Pick;

namespace InvoiceParser
{
	public class InvoicePage
	{
		private readonly string _pageText;
		private string[] _pageLines
		{
			get
			{
				return _pageText.Split(
					new[] { Environment.NewLine },
					StringSplitOptions.None
				);
			}
		}

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

		public SectionType Section { get; set; }

		public int PageNumber { get; set; }
		public int TotalCount { get; set; }

		public List<PickLine> Lines { get; set; }

		public InvoicePage()
		{
			Address = new string[4];
			Lines = new List<PickLine>();
		}

		public InvoicePage(string pageText, string customerName = null) : this()
		{
			_pageText = pageText;
			CustomerName = customerName;

			ExtractCustomerCode();
			ExtractPostCode();
			ExtractAddress();
			ExtractInvoiceNumber();
			ExtractDeliveryDate();
			ExtractInvoiceDate();
			ExtractRouteAndDrop();
			ExtractReference();
			ExtractPageNumber();
			ExtractSectionType();
			ExtractTotalCount();
		}

		private void ExtractCustomerCode()
		{
			// Match customer code
			Regex customerCodeRegex = new Regex(@"(A\/C )([A-Z0-9]+)");
			var customerCodeMatch = customerCodeRegex.Match(_pageText);
			if (customerCodeMatch.Groups.Count < 3)
				throw new InvoiceException("Customer code could not be found");

			string customerCode = customerCodeMatch.Groups[2].Value;
			CustomerCode = customerCode;
		}

		private void ExtractPostCode()
		{
			var postCodeLine = _pageLines[5];

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

		private void ExtractAddress()
		{
			ExtractAddressLine1();
			ExtractAddressLine2();
			ExtractAddressLine3();
			ExtractAddressLine4();
		}

		private void ExtractAddressLine1()
		{
			// Split customer code and address line 1
			//? A/C MCN812 Bannerley Buildings
			Regex addressLineRegex = new Regex(@"(A\/C )([A-Z0-9]+) (.+)");
			var addressLineMatch = addressLineRegex.Match(_pageText);
			if (addressLineMatch.Groups.Count < 4)
				Address[0] = "";
			else
				Address[0] = addressLineMatch.Groups[3].Value.Trim();
		}

		private void ExtractAddressLine2()
		{
			var nameLine = ExtractCustomerNameAndAddressLine();

			if (CustomerName != null)
			{
				Address[1] = nameLine.Replace(CustomerName, "").Trim();
			}
		}

		private void ExtractAddressLine3()
		{
			string addressLine3 = _pageLines[4].Trim();
			Address[2] = addressLine3;
		}

		private void ExtractAddressLine4()
		{
			string addressLine4 = _pageLines[5];
			if (PostCode != null)
				Address[3] = addressLine4.Replace(PostCode, "").Trim();
		}

		private void ExtractInvoiceNumber()
		{
			// Match invoice number
			Regex invoiceNumberRegex = new Regex(@"(Order:)([0-9]+)");
			var invoiceNumberMatch = invoiceNumberRegex.Match(_pageText);
			if (invoiceNumberMatch.Groups.Count < 3)
				throw new InvoiceException();

			// If possible remove trailing 00's
			var invoiceNumber = Convert.ToInt32(invoiceNumberMatch.Groups[2].Value);
			if (invoiceNumber % 100 == 0 && invoiceNumber >= 10000000)
				invoiceNumber /= 100;

			InvoiceNumber = invoiceNumber;
		}

		private void ExtractDeliveryDate()
		{
			// Match delivery date
			Regex deliveryDateRegex = new Regex(@"(Deliver by:)([0-9]{2})(\/)([0-9]{2})(\/)([0-9]{2})");
			var deliveryDateMatch = deliveryDateRegex.Match(_pageText);
			if (deliveryDateMatch.Groups.Count < 7)
				throw new InvoiceException("Delivery date could not be found");

			int dayNumber = Convert.ToInt32(deliveryDateMatch.Groups[2].Value);
			int monthNumber = Convert.ToInt32(deliveryDateMatch.Groups[4].Value);
			int yearNumber = Convert.ToInt32("20" + deliveryDateMatch.Groups[6].Value);

			DeliveryBy = new DateTime(yearNumber, monthNumber, dayNumber);
		}

		private void ExtractInvoiceDate()
		{
			// Match delivery date
			Regex invoiceDateRegex = new Regex(@"(Date :)([0-9]{2})(\/)([0-9]{2})(\/)([0-9]{2})");
			var invoiceDateMatch = invoiceDateRegex.Match(_pageText);
			if (invoiceDateMatch.Groups.Count < 7)
				throw new InvoiceException("Invoice date could not be found");

			int dayNumber = Convert.ToInt32(invoiceDateMatch.Groups[2].Value);
			int monthNumber = Convert.ToInt32(invoiceDateMatch.Groups[4].Value);
			int yearNumber = Convert.ToInt32("20" + invoiceDateMatch.Groups[6].Value);

			Date = new DateTime(yearNumber, monthNumber, dayNumber);
		}

		private void ExtractRouteAndDrop()
		{
			// Match route number
			Regex routeDropRegex = new Regex(@"(Route : )([0-9]+)( \/ )([0-9]+)");
			var routeDropMatch = routeDropRegex.Match(_pageText);
			if (routeDropMatch.Groups.Count < 5)
				throw new InvoiceException("Route and drop numbers could not be found");

			Route = Convert.ToInt32(routeDropMatch.Groups[2].Value);
			Drop = Convert.ToInt32(routeDropMatch.Groups[4].Value);
		}

		private void ExtractReference()
		{
			// Match reference
			Regex referenceRegex = new Regex(@"(Ref:)([a-zA-Z0-9 ]+)");
			var referenceMatch = referenceRegex.Match(_pageText);

			if (referenceMatch.Groups.Count < 3)
			{
				Reference = "";
				return;
			}

			Reference = referenceMatch.Groups[2].Value.Trim();
		}

		private void ExtractPageNumber()
		{
			// Match page number
			Regex pageNumberRegex = new Regex(@"(Page: )([0-9]+)");
			var pageNumberMatch = pageNumberRegex.Match(_pageText);
			if (pageNumberMatch.Groups.Count < 3)
			{
				PageNumber = -1;
				return;
			}

			PageNumber = Convert.ToInt32(pageNumberMatch.Groups[2].Value);
		}

		private void ExtractSectionType()
		{
			if (_pageText.Contains("1-Frozen"))
				Section = SectionType.Frozen;
			else if (_pageText.Contains("2-Bulk Frozen"))
				Section = SectionType.Bulk;
			else if (_pageText.Contains("5-Ambient"))
				Section = SectionType.Ambient;
			else if (_pageText.Contains("6-Bulk Ambient"))
				Section = SectionType.AmbientBulk; 
			else 
				Section = SectionType.Invalid;
		}

		private void ExtractTotalCount()
		{ 
			// Match total count
			Regex totalCountRegex = new Regex(@"(Total count \| )([0-9]+)");
			var totalCountMatch = totalCountRegex.Match(_pageText);
			if (totalCountMatch.Groups.Count == 3)
			{
				TotalCount = Convert.ToInt32(totalCountMatch.Groups[2].Value);
				return;
			}

			// Match total units
			Regex totalUnitsRegex = new Regex(@"(Total units : )([0-9]+)");
			var totalUnitsMatch = totalUnitsRegex.Match(_pageText);
			if (totalUnitsMatch.Groups.Count == 3)
			{
				TotalCount = Convert.ToInt32(totalUnitsMatch.Groups[2].Value);
				return;
			}

			TotalCount = -1;
		}

		public string ExtractCustomerNameAndAddressLine()
		{
			// Customer name and address line 2
			//? Batleys Hadfield Road 730 24 Hadfield Road 1-Frozen
			return _pageLines[3]
				.Replace("1-Frozen", "")
				.Replace("2-Bulk Frozen", "")
				.Replace("5-Ambient", "")
				.Replace("6-Bulk Ambient", "")
				.Trim();
		}
	}
}
