using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfiumViewer;

namespace InvoiceParserUnitTests
{
	static class TestPages
	{
		private static readonly string _testInvoicesFolderPath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\TestInvoices\\";
		
		public static string McNabs_Page1_NotFull;
		public static string[] Hadfield30th_Frozen_Pages;
		public static string Hadfield30th_Page1_BulkFrozen;

		public static string GetPageText(string filename, int pageIndex)
		{
			using (var s = File.Open(filename, FileMode.Open))
			{

				PdfDocument doc = PdfDocument.Load(s);

				return doc.GetPdfText(pageIndex);
			}
		}

		public static void InitTestPages()
		{
			McNabs_Page1_NotFull = GetPageText($"{_testInvoicesFolderPath}McNabs-OnePage-NotFull.pdf", 0);

			var hadfield30thPath = $"{_testInvoicesFolderPath}Hadfield30th-5Pages-Frozen-BulkFrozen.pdf";
			Hadfield30th_Frozen_Pages = new []
			{
				GetPageText(hadfield30thPath, 0),
				GetPageText(hadfield30thPath, 1),
				GetPageText(hadfield30thPath, 2),
				GetPageText(hadfield30thPath, 3),
			};

			Hadfield30th_Page1_BulkFrozen = GetPageText(hadfield30thPath, 4);

		}
	}
}
