using InvoiceParser;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace InvoiceParserUnitTests
{
	[TestClass]
	public class PickLineTests
	{
		[TestInitialize]
		public void Setup()
		{
		}

		[TestMethod]
		public void LineParsing_Simple()
		{
			var lineText = "E4600/B 8651 12 Franco's Splendor Chocolate 200ml 10 _____ 34 05038486410100";
			var line = new PickLine(lineText);

			Assert.AreEqual("E4600/B", line.Location);
			Assert.AreEqual(8651, line.Code);
			Assert.AreEqual(12, line.Pack);
			Assert.AreEqual("Franco's Splendor Chocolate", line.Description);
			Assert.AreEqual("200ml", line.Size);
			Assert.AreEqual(10, line.Ordered);
			Assert.AreEqual(34, line.LineNumber);
			Assert.AreEqual(05038486410100, line.Barcode);
		}

		[TestMethod]
		public void LineParsing_Single()
		{
			var lineText = "E4600/B 8651 1 Franco's Splendor Chocolate 200ml Single 10 _____ 34 05038486410100";
			var line = new PickLine(lineText);

			Assert.AreEqual("E4600/B", line.Location);
			Assert.AreEqual(8651, line.Code);
			Assert.AreEqual(1, line.Pack);
			Assert.AreEqual("Franco's Splendor Chocolate", line.Description);
			Assert.AreEqual("200ml", line.Size);
			Assert.AreEqual(10, line.Ordered);
			Assert.AreEqual(34, line.LineNumber);
			Assert.AreEqual(05038486410100, line.Barcode);
		}

		[TestMethod]
		public void LineParsing_Free()
		{
			var lineText = "E4600/B 8651 12 Franco's Splendor Chocolate 200ml *FREE* 10 _____ 34 05038486410100";
			var line = new PickLine(lineText);

			Assert.AreEqual("E4600/B", line.Location);
			Assert.AreEqual(8651, line.Code);
			Assert.AreEqual(12, line.Pack);
			Assert.AreEqual("Franco's Splendor Chocolate", line.Description);
			Assert.AreEqual("200ml", line.Size);
			Assert.AreEqual(10, line.Ordered);
			Assert.AreEqual(34, line.LineNumber);
			Assert.AreEqual(05038486410100, line.Barcode);
		}

		[TestMethod]
		public void LineParsing_SingleFree()
		{
			var lineText = "E4600/B 8651 1 Franco's Splendor Chocolate 200ml Single *FREE* 10 _____ 34 05038486410100";
			var line = new PickLine(lineText);

			Assert.AreEqual("E4600/B", line.Location);
			Assert.AreEqual(8651, line.Code);
			Assert.AreEqual(1, line.Pack);
			Assert.AreEqual("Franco's Splendor Chocolate", line.Description);
			Assert.AreEqual("200ml", line.Size);
			Assert.AreEqual(10, line.Ordered);
			Assert.AreEqual(34, line.LineNumber);
			Assert.AreEqual(05038486410100, line.Barcode);
		}

		[TestMethod]
		public void LineParsing_NoBarcode()
		{
			var lineText = "A 100/A 3915 24 Calippo Orange FOC 105ml 2 _____ 37";
			var line = new PickLine(lineText);

			Assert.AreEqual("A 100/A", line.Location);
			Assert.AreEqual(3915, line.Code);
			Assert.AreEqual(24, line.Pack);
			Assert.AreEqual("Calippo Orange FOC", line.Description);
			Assert.AreEqual("105ml", line.Size);
			Assert.AreEqual(2, line.Ordered);
			Assert.AreEqual(37, line.LineNumber);
			Assert.AreEqual(-1, line.Barcode);
		}

		[TestMethod]
		public void LineParsing_SingleNoBarcode()
		{
			var lineText = "A 100/A 3915 1 Calippo Orange FOC 105ml Single 2 _____ 37";
			var line = new PickLine(lineText);

			Assert.AreEqual("A 100/A", line.Location);
			Assert.AreEqual(3915, line.Code);
			Assert.AreEqual(1, line.Pack);
			Assert.AreEqual("Calippo Orange FOC", line.Description);
			Assert.AreEqual("105ml", line.Size);
			Assert.AreEqual(2, line.Ordered);
			Assert.AreEqual(37, line.LineNumber);
			Assert.AreEqual(-1, line.Barcode);
		}

		[TestMethod]
		public void LineParsing_FreeNoBarcode()
		{
			var lineText = "A 100/A 3915 24 Calippo Orange FOC 105ml *FREE* 2 _____ 37";
			var line = new PickLine(lineText);

			Assert.AreEqual("A 100/A", line.Location);
			Assert.AreEqual(3915, line.Code);
			Assert.AreEqual(24, line.Pack);
			Assert.AreEqual("Calippo Orange FOC", line.Description);
			Assert.AreEqual("105ml", line.Size);
			Assert.AreEqual(2, line.Ordered);
			Assert.AreEqual(37, line.LineNumber);
			Assert.AreEqual(-1, line.Barcode);
		}

		[TestMethod]
		public void LineParsing_SingleFreeNoBarcode()
		{
			var lineText = "A 100/A 3915 1 Calippo Orange FOC 105ml Single *FREE* 2 _____ 37";
			var line = new PickLine(lineText);

			Assert.AreEqual("A 100/A", line.Location);
			Assert.AreEqual(3915, line.Code);
			Assert.AreEqual(1, line.Pack);
			Assert.AreEqual("Calippo Orange FOC", line.Description);
			Assert.AreEqual("105ml", line.Size);
			Assert.AreEqual(2, line.Ordered);
			Assert.AreEqual(37, line.LineNumber);
			Assert.AreEqual(-1, line.Barcode);
		}

		[TestMethod]
		public void LineParsing_MaxDescriptionSingle()
		{
			var lineText = "C2900/B 6233 1 Kellys of Cornwall Clotted Cream Vanilla Bean Seed4.5ltr Single 10 _____ 6 15026646000596";
			var line = new PickLine(lineText);

			Assert.AreEqual("C2900/B", line.Location);
			Assert.AreEqual(6233, line.Code);
			Assert.AreEqual(1, line.Pack);
			Assert.AreEqual("Kellys of Cornwall Clotted Cream Vanilla Bean Seed", line.Description);
			Assert.AreEqual("4.5ltr", line.Size);
			Assert.AreEqual(10, line.Ordered);
			Assert.AreEqual(6, line.LineNumber);
			Assert.AreEqual(15026646000596, line.Barcode);
		}
	}
}