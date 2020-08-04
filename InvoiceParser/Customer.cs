using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceParser
{
	class Customer
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string[] Address { get; set; }
		public string PreferredName { get; set; }
		public string QuickSelectText { get; set; }
	}
}
