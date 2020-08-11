using System.Linq;
using InvoiceTools.InvoiceModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvoiceParserUnitTests.InvoiceModelTests
{
	[TestClass]
	public class InvoiceTests
	{
		[TestInitialize]
		public void Setup()
		{
			TestPages.InitTestPages();
		}

		[TestMethod]
		public void TestAddInvoicePages_Hadfield30th()
		{
			var invoice = new Invoice();
			foreach (var pageText in TestPages.Hadfield30th_Frozen_Pages)
			{
				var page = new InvoicePage(pageText);
				invoice.AddPage(page);
			}

			var bulkPage = new InvoicePage(TestPages.Hadfield30th_Page1_BulkFrozen);
			invoice.AddPage(bulkPage);

			Assert.AreEqual(453, invoice.Frozen.Sum(x => x.Ordered));
			Assert.AreEqual(130, invoice.BulkFrozen.Sum(x => x.Ordered));

			Assert.AreEqual(4, invoice.Frozen.Max(x => x.PageNumber));
			Assert.AreEqual(1, invoice.BulkFrozen.Max(x => x.PageNumber));
		}

		[TestMethod]
		public void TestAddInvoicePages_Hadfield27th()
		{
			var invoice = new Invoice();
			foreach (var pageText in TestPages.Hadfield27th_Frozen_Pages)
			{
				var page = new InvoicePage(pageText);
				invoice.AddPage(page);
			}

			var bulkPage = new InvoicePage(TestPages.Hadfield27th_BulkAmbient_Page);
			invoice.AddPage(bulkPage);

			Assert.AreEqual(511, invoice.Frozen.Sum(x => x.Ordered));
			Assert.AreEqual(75, invoice.BulkAmbient.Sum(x => x.Ordered));

			Assert.AreEqual(3, invoice.Frozen.Max(x => x.PageNumber));
			Assert.AreEqual(1, invoice.BulkAmbient.Max(x => x.PageNumber));

			var jerseyGoldLine = invoice.BulkAmbient.First();
			Assert.AreEqual("J06/2R", jerseyGoldLine.Location);
			Assert.AreEqual("J06/2R", jerseyGoldLine.SecondLocation);
		}
	}
}
