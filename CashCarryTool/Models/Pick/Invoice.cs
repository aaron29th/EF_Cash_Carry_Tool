using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.Models.Pick
{
	class Invoice
	{
		public int InvoiceNumber { get; set; }

		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }

		public DateTime DeliveryBy { get; set; }
		public DateTime Date { get; set; }

		public int Route { get; set; }
		public int Drop { get; set; }

		public string Address { get; set; }
		public string PostCode { get; set; }

		public Section Ambient { get; set; }
		public Section Frozen { get; set; }
		public Section Bulk { get; set; }
	}
}
