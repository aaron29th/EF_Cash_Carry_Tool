using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InvoiceParser
{
	public class BulkPickLine : PickLine
	{
		public string SecondLocation { get; set; }

		public BulkPickLine()
		{
			
		}

		public BulkPickLine(string lineText, string secondLineText) : base(lineText)
		{
			
		}
	}
}
