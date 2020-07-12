using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels
{
	public class Invoice
	{
		public string InvoiceNumber { get; set; }
		public int AmbientUnits { get; set; }
		public int BulkUnits { get; set; }
		public int MixedUnits { get; set; }
	}
}
