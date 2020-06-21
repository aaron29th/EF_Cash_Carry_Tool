using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;

namespace Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels
{
	class FrontSheet
	{
		public Document Document;
		private Section _currentSection;

		public string Title { get; set; }
		public string CustomerCode { get; set; }
		public string DeliveryDate { get; set; }

		public List<Pallet> Pallets { get; set; }
		public int NumCopiesPerPallet { get; set; }
		public bool SecondRun { get; set; }
		public string VehicleRegistration { get; set; }

		public List<string> InvoiceNumbers { get; set; }


	}
}
