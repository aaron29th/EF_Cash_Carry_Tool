using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels
{
	class Pallet
	{
		public bool Selected { get; set; }
		//public string Number { get; set; }
		//public string AdditionalText { get; set; }
		public PalletType Type { get; set; }

		public Pallet()
		{
			Selected = true;
		}
	}
}
