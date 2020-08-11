using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using InvoiceTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfiumViewer;

namespace InvoiceParserUnitTests
{
	[TestClass]
	public class InvoiceParserTests
	{
		[TestMethod]
		public void PdfToInvoicesTest_Hadfield27th()
		{
			using (var s = File.Open(TestPages.Hadfield27thPath, FileMode.Open))
			{
				PdfDocument doc = PdfDocument.Load(s);

				var invoices = InvoiceParser.PdfDocToInvoices(doc);

				Assert.AreEqual(1, invoices.Count);
				Assert.AreEqual("BES730", invoices[0].CustomerCode);
				Assert.IsTrue(invoices[0].Frozen.Select(x => x.PageNumber).Distinct().Count() == 3);
				Assert.IsTrue(invoices[0].BulkAmbient.Select(x => x.PageNumber).Distinct().Count() == 1);
			}
		}
	}
}
