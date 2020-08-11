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
		public static string Hadfield30thPath = $"{_testInvoicesFolderPath}Hadfield30th-5Pages-Frozen-BulkFrozen.pdf";
		public static string Hadfield27thPath = $"{_testInvoicesFolderPath}Hadfield27th-4pages-Frozen-BulkAmbient.pdf";

		public static string McNabs_Page1_NotFull;

		public static string[] Hadfield30th_Frozen_Pages;
		public static string Hadfield30th_Page1_BulkFrozen;

		public static string[] Hadfield27th_Frozen_Pages;
		public static string Hadfield27th_BulkAmbient_Page;

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

			Hadfield30th_Frozen_Pages = new []
			{
				GetPageText(Hadfield30thPath, 0),
				GetPageText(Hadfield30thPath, 1),
				GetPageText(Hadfield30thPath, 2),
				GetPageText(Hadfield30thPath, 3)
			};

			Hadfield30th_Page1_BulkFrozen = GetPageText(Hadfield30thPath, 4);

			Hadfield27th_Frozen_Pages = new[]
			{
				GetPageText(Hadfield27thPath, 0),
				GetPageText(Hadfield27thPath, 1),
				GetPageText(Hadfield27thPath, 2),
			};

			Hadfield27th_BulkAmbient_Page = GetPageText(Hadfield27thPath, 3);

		}
	}
}
