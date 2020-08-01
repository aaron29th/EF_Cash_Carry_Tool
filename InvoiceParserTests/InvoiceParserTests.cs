using InvoiceParser;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace InvoiceParserTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			Assert.Pass();
		}

		[Test]
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
	}
}