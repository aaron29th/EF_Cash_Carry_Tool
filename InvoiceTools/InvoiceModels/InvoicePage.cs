using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using InvoiceTools.DirectoryModels;
using InvoiceTools.Forms;
using InvoiceTools.Models;

namespace InvoiceTools.InvoiceModels
{
	public class InvoicePage
	{
		private readonly string _pageText;
		private readonly string[] _pageLines;

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

		public InvoicePage(string pageText) : this()
		{
			_pageText = pageText;
			_pageLines = pageText.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

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

			ExtractPickLines();

			ResourcesDirectory.AddCustomer(new Customer()
			{
				Code = CustomerCode,
				PreferredName = CustomerName,
				QuickSelectText = CustomerName,
				Name = CustomerName,
				AddressLine1 = Address[0],
				AddressLine2 = Address[1],
				AddressLine3 = Address[2],
				AddressLine4 = Address[3],
				PostCode = PostCode
			});
		}

		#region region Invoice Details

		private void ExtractCustomerCode()
		{
			// Match customer code
			Regex customerCodeRegex = new Regex(@"(A\/C )([A-Z0-9]+)");
			var customerCodeMatch = customerCodeRegex.Match(_pageLines[2]);
			if (!customerCodeMatch.Success)
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
			if (!postCodeMatch.Success)
			{
				PostCode = "";
				return;
			}

			PostCode = postCodeMatch.Groups[0].Value;
		}

		

		private void ExtractAddress()
		{
			ExtractAddressLine1();
			FindCustomerNameAndAddressLine2();
			ExtractAddressLine3();
			ExtractAddressLine4();
		}

		private void ExtractAddressLine1()
		{
			// Split customer code and address line 1
			//? A/C MCN812 Bannerley Buildings
			Regex addressLineRegex = new Regex(@"(A\/C )([A-Z0-9]+) (.+)");
			var addressLineMatch = addressLineRegex.Match(_pageLines[2]);
			if (!addressLineMatch.Success)
				Address[0] = "";
			else
				Address[0] = addressLineMatch.Groups[3].Value.Trim();
		}

		private void FindCustomerNameAndAddressLine2()
		{
			var nameLine = ExtractCustomerNameAndAddressLine();
			var customers = ResourcesDirectory.GetCustomers();

			var customer = customers.FirstOrDefault(x => x.Code == CustomerCode);

			if (customer == null)
			{
				// Split line with for manually
				using (var form = new SplitCustomerNameAddressForm(nameLine))
				{
					form.ShowDialog();

					CustomerName = form.CustomerName;
					Address[1] = form.CustomerAddressLine;
				}
			}
			else
			{
				CustomerName = customer.Name;
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
			var invoiceNumberMatch = invoiceNumberRegex.Match(_pageLines[0]);
			if (!invoiceNumberMatch.Success)
				throw new InvoiceException("Invoice number not found");

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
			var deliveryDateMatch = deliveryDateRegex.Match(_pageLines[0]);
			if (!deliveryDateMatch.Success)
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
			var invoiceDateMatch = invoiceDateRegex.Match(_pageLines[1]);
			if (!invoiceDateMatch.Success)
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
			var routeDropMatch = routeDropRegex.Match(_pageLines[0]);
			if (!routeDropMatch.Success)
				throw new InvoiceException("Route and drop numbers could not be found");

			Route = Convert.ToInt32(routeDropMatch.Groups[2].Value);
			Drop = Convert.ToInt32(routeDropMatch.Groups[4].Value);
		}

		private void ExtractReference()
		{
			// Match reference
			Regex referenceRegex = new Regex(@"(Ref:)([a-zA-Z0-9 ]+)");
			var referenceMatch = referenceRegex.Match(_pageLines[1]);

			if (!referenceMatch.Success)
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
			var pageNumberMatch = pageNumberRegex.Match(_pageLines[0]);
			if (!pageNumberMatch.Success)
			{
				PageNumber = -1;
				return;
			}

			PageNumber = Convert.ToInt32(pageNumberMatch.Groups[2].Value);
		}

		private void ExtractSectionType()
		{
			if (_pageLines[3].Contains("1-Frozen"))
				Section = SectionType.Frozen;
			else if (_pageLines[3].Contains("2-Bulk Frozen"))
				Section = SectionType.Bulk;
			else if (_pageLines[3].Contains("5-Ambient"))
				Section = SectionType.Ambient;
			else if (_pageLines[3].Contains("6-Bulk Ambient"))
				Section = SectionType.AmbientBulk; 
			else 
				Section = SectionType.Invalid;
		}

		private void ExtractTotalCount()
		{ 
			// Match total count
			Regex totalCountRegex = new Regex(@"(Total count \| )([0-9]+)");
			var totalCountMatch = totalCountRegex.Match(_pageLines[9]);
			if (totalCountMatch.Success)
			{
				TotalCount = Convert.ToInt32(totalCountMatch.Groups[2].Value);
				return;
			}

			// Match total units
			Regex totalUnitsRegex = new Regex(@"(Total units : )([0-9]+)");
			var totalUnitsMatch = totalUnitsRegex.Match(_pageText);
			if (totalUnitsMatch.Success)
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

		#endregion

		private void ExtractPickLines()
		{
			int firstLineIndex = PageNumber == 1 ? 14 : 7;
			int numInvalidLinesAtEnd = _pageLines.Last().StartsWith(" Est") ? 3 : 0;
			int totalLines = _pageLines.Length - firstLineIndex - numInvalidLinesAtEnd;

			var lines = _pageLines.Skip(firstLineIndex).Take(totalLines).ToArray();

			for (int lineIndex = 0; lineIndex < lines.Count(); lineIndex++)
			{
				// Null if last element
				var secondLine = lineIndex == totalLines - 1 ? null : lines[lineIndex + 1];
				var pickLine = new PickLine(lines[lineIndex], secondLine)
				{
					PickLineNumber = lineIndex + 1,
					PageNumber = PageNumber
				};

				Lines.Add(pickLine);

				// If second line is location skip
				if (pickLine.SecondLocation != null)
					lineIndex++;
			}
		}
	}
}
