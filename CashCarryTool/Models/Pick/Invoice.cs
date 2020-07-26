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
		private IPdfDocument _doc;

		public int InvoiceNumber { get; set; }

		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }

		public DateTime DeliveryBy { get; set; }
		public DateTime Date { get; set; }

		public int Route { get; set; }
		public int Drop { get; set; }

		public List<string> Address { get; set; }
		public string PostCode { get; set; }

		public Section Frozen { get; set; }
		public Section Bulk { get; set; }
		public Section Ambient { get; set; }
		public Section AmbientBulk { get; set; }

		public Invoice()
		{
			Address = new List<string>();

			Frozen = new Section();
			Bulk = new Section();
			Ambient = new Section();
			AmbientBulk = new Section();
		}

		public void ProcessInvoicePdfDocument(IPdfDocument doc)
		{
			_doc = doc;

			for (int pageIndex = 0; pageIndex < _doc.PageCount; pageIndex++)
			{
				ProcessPage(pageIndex);
			}
		}

		private void ProcessPage(int pageIndex)
		{
			if (_doc == null || _doc.PageCount <= pageIndex)
				return;


			int pageNumber = ExtractPageNumber(pageIndex);
			var sectionType = ExtractSectionType(pageIndex);

			// Check page hasn't already been processed
			if (sectionType == SectionType.Frozen && Frozen.ProcessedPages.Contains(pageNumber))
				throw new InvoiceException();
			if (sectionType == SectionType.Bulk && Bulk.ProcessedPages.Contains(pageNumber))
				throw new InvoiceException();
			if (sectionType == SectionType.Ambient && Ambient.ProcessedPages.Contains(pageNumber))
				throw new InvoiceException();
			if (sectionType == SectionType.AmbientBulk && AmbientBulk.ProcessedPages.Contains(pageNumber))
				throw new InvoiceException();

			// Extract and check on every page
			ExtractCheckCustomerCode(pageIndex);
			ExtractInvoiceNumber(pageIndex);
			ExtractDeliveryDate(pageIndex);

			// Only extract on first page
			if (pageIndex != 0)
				return;
			ExtractPostCode(pageIndex);
			ExtractCustomerNameAndAddress(pageIndex);
		}



		private void ExtractCheckCustomerCode(int pageIndex)
		{
			var pageText = _doc.GetPdfText(pageIndex);

			// Match customer code
			Regex customerCodeRegex = new Regex(@"(A\/C )([A-Z0-9]+)");
			var customerCodeMatch = customerCodeRegex.Match(pageText);
			if (customerCodeMatch.Groups.Count < 3)
				throw new InvoiceException();

			string customerCode = customerCodeMatch.Groups[2].Value;
			// Check customer code is consistent
			if (!String.IsNullOrEmpty(CustomerCode) && CustomerCode != customerCode)
				throw new InvoiceException();
			CustomerCode = customerCode;
		}

		private void ExtractPostCode(int pageIndex)
		{
			string[] lines = _doc.GetPdfText(pageIndex).Split(
				new[] { Environment.NewLine },
				StringSplitOptions.None
			);

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
			string[] lines = _doc.GetPdfText(pageIndex).Split(
				new[] { Environment.NewLine },
				StringSplitOptions.None
			);

			if (CustomerCode != null)
			{
				string addressLine1 = lines[2];
				int addressLine1Start = addressLine1.IndexOf(CustomerCode, StringComparison.Ordinal);
				addressLine1 = addressLine1.Substring(addressLine1Start + CustomerCode.Length);
				Address.Add(addressLine1.Trim());
			}
			else
			{
				Address.Add("");
			}

			if (lines.Length < 3)
				throw new InvoiceException(); ;

			var nameLine = lines[3]
				.Replace("1-Frozen", "")
				.Replace("?-Bulk", "")
				.Replace("?-Ambient", "")
				.Replace("6-Bulk Ambient", "")
				.Trim();

			using (var form = new SplitCustomerNameAddressForm(nameLine))
			{
				form.ShowDialog();

				CustomerName = form.CustomerName;
				Address.Add(form.CustomerAddressLine);
			}

			string addressLine3 = lines[4].Trim();
			Address.Add(addressLine3);

			if (PostCode == null)
				return;
			string addressLine4 = lines[5].Replace(PostCode, "").Trim();
			Address.Add(addressLine4);
		}

		private void ExtractInvoiceNumber(int pageIndex)
		{
			var pageText = _doc.GetPdfText(pageIndex);

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
				throw new InvoiceException();
			InvoiceNumber = invoiceNumber;
		}

		private void ExtractDeliveryDate(int pageIndex)
		{
			var pageText = _doc.GetPdfText(pageIndex);

			// Match delivery date
			Regex deliveryDateRegex = new Regex(@"(Deliver by:)([0-9]{2})(\/)([0-9]{2})(\/)([0-9]{2})");
			var deliveryDateMatch = deliveryDateRegex.Match(pageText);
			if (deliveryDateMatch.Groups.Count < 7)
				throw new InvoiceException();

			int dayNumber = Convert.ToInt32(deliveryDateMatch.Groups[2].Value);
			int monthNumber = Convert.ToInt32(deliveryDateMatch.Groups[4].Value);
			int yearNumber = Convert.ToInt32(deliveryDateMatch.Groups[6].Value);

			DeliveryBy = new DateTime(yearNumber, monthNumber, dayNumber);
		}

		private int ExtractPageNumber(int pageIndex)
		{
			var pageText = _doc.GetPdfText(pageIndex);

			// Match customer code
			Regex pageNumberRegex = new Regex(@"(Page: )([0-9]+)");
			var pageNumberMatch = pageNumberRegex.Match(pageText);
			if (pageNumberMatch.Groups.Count < 3)
				return -1;
			return Convert.ToInt32(pageNumberMatch.Groups[2].Value);
		}

		private SectionType ExtractSectionType(int pageIndex)
		{
			var pageText = _doc.GetPdfText(pageIndex);

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
	}
}
