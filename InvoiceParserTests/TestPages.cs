using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfiumViewer;

namespace InvoiceParserTests
{
	static class TestPages
	{
		private static readonly string _testInvoicesFolderPath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\TestInvoices\\";
		public static string McNabs_Page1_NotFull;

		public static string GetPageText(string filename, int pageIndex)
		{
			var s = File.Open(filename, FileMode.Open);

			PdfDocument doc = PdfDocument.Load(s);

			return doc.GetPdfText(pageIndex);
		}

		public static void InitTestPages()
		{
			McNabs_Page1_NotFull = GetPageText($"{_testInvoicesFolderPath}McNabs-OnePage-NotFull.pdf", 0);
		}
	}
}
